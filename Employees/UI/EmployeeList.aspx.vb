Imports Employees.Entities
Imports Employees.Services

Public Class EmployeeList
    Inherits System.Web.UI.Page

    Private _employeeService As New EmployeeService
    Private _departmentService As New DepartmentService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Startup()
    End Sub

    'Public Function GetEmployees() As IQueryable(Of Employees.Entities.Employee)
    '    Dim query As IQueryable(Of Employee) = _db.Employees

    '    Return query
    'End Function
    Private Sub Startup()
        BindRepeater()
        Me.drpDep.DataSource = _departmentService.GetAllDepartments
        Me.drpDep.DataBind()
    End Sub

    Private Sub BindRepeater()
        rptEmployee.DataSource = _employeeService.GetAllEmployees
        rptEmployee.DataBind()
    End Sub

    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        Dim departmentId = Me.drpDep.SelectedValue.ToString
        Dim employeeName = Request.Form("EmployeeName")
        Dim employee As New Employee
        employee.DepartmentID = Convert.ToInt32(departmentId)
        employee.EmployeeName = employeeName
        _employeeService.SaveEmployee(employee)
        BindRepeater()
    End Sub
End Class