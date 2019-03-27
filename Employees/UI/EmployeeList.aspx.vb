Imports Employees.Entities
Imports Employees.Services

Public Class EmployeeList
    Inherits System.Web.UI.Page

    Private _employeeService As New EmployeeService
    Private _departmentService As New DepartmentService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Startup()
    End Sub

    Private Sub Startup()
        BindRepeater()
        Me.drpDep.DataSource = _departmentService.GetAllDepartments
        Me.drpDep.DataBind()
    End Sub

    Private Sub BindRepeater()
        rptEmployee.DataSource = _employeeService.GetAllEmployees '.Where(Function(e) e.Valid)
        rptEmployee.DataBind()
    End Sub

    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        Dim formType = Request.Form("formType")
        Dim id = Request.Form("EmployeeIdHd").ToString
        If formType = "delete" Then
            DeleteRecord(id)
        Else

        End If

        Dim departmentId = Me.drpDep.SelectedValue.ToString
        Dim employeeName = Request.Form("EmployeeName")
        Dim mobileno = Request.Form("MobileNo")
        Dim email = Request.Form("Email")
        Dim salary = Request.Form("Salary")
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
        employee.Salary = salary
        _employeeService.SaveEmployee(employee)
        BindRepeater()
    End Sub

    Public Sub DeleteRecord(id As Integer)

        _employeeService.DeleteEmployee(id)
        BindRepeater()
    End Sub

End Class