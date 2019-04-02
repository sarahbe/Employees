Imports System.Web.Services
Imports Employees.Entities
Imports Employees.Services

Public Class CompensationTypeList
    Inherits System.Web.UI.Page

    Private Shared _salaryService As New SalaryService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindRepeater()
        End If
    End Sub

    Private Sub BindRepeater()
        Me.rtpCompensationType.DataSource = _salaryService.GetAllCompenstationTypes().Where(Function(v) v.Valid)
        Me.rtpCompensationType.DataBind()
    End Sub

    <WebMethod>
    Public Shared Function SaveCompensationType(CompensationTypeName As String) As String
        Dim dep As New CompensationType
        dep.CompensationTypeName = CompensationTypeName
        _salaryService.SaveCompensationType(dep)
        Return "success"
    End Function

    <WebMethod>
    Public Shared Function DeleteCompensationType(CompensationTypeID As String) As String
        _salaryService.DeleteCompensationType(CompensationTypeID)
        Return "delete success"
    End Function
End Class