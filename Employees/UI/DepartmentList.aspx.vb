Imports System.Web.Services
Imports Employees.Entities
Imports Employees.Services

Public Class DepartmentList
    Inherits System.Web.UI.Page

    Private Shared _departmentService As New DepartmentService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Startup()
    End Sub

    Private Sub Startup()
        Me.rtpDepartment.DataSource = _departmentService.GetAllDepartments()
        Me.rtpDepartment.DataBind()
    End Sub

    <WebMethod>
    Public Shared Function SaveDepartment(DepartmentName As String) As String
        Dim dep As New Department
        dep.DepartmentName = DepartmentName
        _departmentService.SaveDepartment(dep)
        Return "success"
    End Function

End Class