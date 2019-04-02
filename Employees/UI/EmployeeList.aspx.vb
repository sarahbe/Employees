Imports Employees.Entities
Imports Employees.Services

Public Class EmployeeList
    Inherits System.Web.UI.Page

    Private _employeeService As New EmployeeService
    Private _departmentService As New DepartmentService
    Private _salaryService As New SalaryService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Startup()

        End If
    End Sub

    Private Sub Startup()
        BindRepeater()
        Dim deps = _departmentService.GetAllDepartments.Where(Function(d) d.Valid)
        Me.drpDep.DataSource = deps
        Me.drpDep.DataBind()
    End Sub

    Private Sub BindRepeater()
        rptEmployee.DataSource = _employeeService.GetAllEmployees.OrderByDescending(Function(v) v.Valid)
        rptEmployee.DataBind()
    End Sub

    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        Dim formType = Request.Form("formType")
        Dim id = Request.Form("EmployeeIdHd").ToString
        If formType = "delete" Then
            DeleteRecord(id)
            Return
        End If

        Dim departmentId = Me.drpDep.SelectedValue.ToString
        Dim employeeName = Request.Form("EmployeeName")
        Dim mobileno = Request.Form("MobileNo")
        Dim email = Request.Form("Email")
        'Dim salary = Request.Form("Salary")
        Dim birthdate = Date.Parse(Request.Form("Birthdate"))
        Dim employee As New Employee


        If id <> "" Then
            employee = _employeeService.GetEmployee(id)
        End If
        employee.DepartmentID = Convert.ToInt32(departmentId)
        employee.EmployeeName = employeeName
        employee.MobileNo = mobileno
        employee.Birthdate = birthdate
        employee.Email = email
        'employee.Salary = salary
        _employeeService.SaveEmployee(employee)
        BindRepeater()
    End Sub

    Public Sub DeleteRecord(id As Integer)

        _employeeService.DeleteEmployee(id)
        BindRepeater()
    End Sub

    'Private Sub rptEmployee_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptEmployee.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Header Then
    '        Dim row As System.Web.UI.HtmlControls.HtmlTableRow = e.Item.FindControl("rowCol")

    '        row.BgColor = "Red"
    '    End If
    'End Sub
    Protected Function GetClassForColor(data As Object) As String
        Dim rowOption = data
        If Not rowOption.Valid Then
            Return "background-color:LightGray"
        End If
        Return True
    End Function
End Class