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
        Me.rtpDepartment.DataSource = _departmentService.GetAllDepartments().Where(Function(x) x.Valid)
        Me.rtpDepartment.DataBind()
    End Sub

    <WebMethod>
    Public Shared Function SaveDepartment(DepartmentName As String, DepartmentId As String) As String
        'If checkDuplicatedDepartment(DepartmentName) Then
        '    'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('Already used name')", True)
        '    Return False
        'End If
        Dim dep As New Department

        If DepartmentId <> "" Then
            dep = _departmentService.GetDepartment(DepartmentId)
        End If
        dep.DepartmentName = DepartmentName
        _departmentService.SaveDepartment(dep)
        Return "success"
    End Function

    <WebMethod>
    Public Shared Function DeleteDepartment(DepartmentId As String) As String
        _departmentService.DeleteDepartment(DepartmentId)
        Return "delete success"
    End Function

    Private Shared Function checkDuplicatedDepartment(departmentName As String) As Boolean
        Dim dep = _departmentService.GetDepartmentByName(departmentName)
        If dep.Any Then
            'Response.Write("<script language=""javascript"">alert('Congratulations!');</script>")

            Return True
        End If
        Return False
    End Function
End Class