Imports Employees.Entities
Imports Employees.Services

Public Class DepartmentList
    Inherits System.Web.UI.Page

    Private _departmentService As New DepartmentService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Startup()
    End Sub

    Private Sub Startup()
        Me.rtpDepartment.DataSource = _departmentService.GetAllDepartments()
        Me.rtpDepartment.DataBind()
    End Sub

    Public Sub SomeEvent_click()
        Dim a = Request.Form("DepartmentName")
        Dim b = 3

    End Sub

End Class