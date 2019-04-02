Imports System.Web.Services
Imports Employees.Entities
Imports Employees.Services

Public Class SalaryCalculation
    Inherits System.Web.UI.Page

    Private _employeeService As New EmployeeService
    Private _salaryService As New SalaryService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindControls()
        End If
    End Sub

    Private Sub BindControls()
        Me.drpEmployee.DataSource = _employeeService.GetAllEmployees.Where(Function(e) e.Valid)
        Me.drpEmployee.DataBind()
        Me.drpEmployee.Items.Insert(0, New ListItem(String.Empty, String.Empty))
        Me.drpEmployee.SelectedIndex = 0
    End Sub


    Private Sub BindRepeater()
        If Me.drpEmployee.SelectedIndex = 0 Then
            Me.rptSalary.DataSource = New List(Of Salary)
            Me.rptSalary.DataBind()
        Else
            Me.rptSalary.DataSource = _salaryService.GetSalaryByEmployee(Me.drpEmployee.SelectedValue).Where(Function(s) s.CompensationType.Valid)
            Me.rptSalary.DataBind()
        End If

    End Sub



    Private Sub drpEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpEmployee.SelectedIndexChanged

        BindRepeater()
        Me.updSalary.Update()
    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As EventArgs) Handles btnSave.ServerClick
        Dim employeeId = Me.drpEmployee.SelectedValue.ToString
        Dim salaryList As New List(Of Salary)
        For Each item As RepeaterItem In Me.rptSalary.Items
            If item.ItemType = ListItemType.Item OrElse item.ItemType = ListItemType.AlternatingItem Then
                Dim amount As HtmlInputControl = item.FindControl("Amount")
                Dim salaryIdFld As HiddenField = item.FindControl("hdnIdSalary")
                Dim compIDFld As HiddenField = item.FindControl("hdnIdComp")
                Dim salaryId = salaryIdFld.Value
                Dim compID = compIDFld.Value
                Dim salary = New Salary
                If salaryId <> "0" Then
                    salary = _salaryService.GetSalary(salaryId)
                End If
                salary.EmployeeID = employeeId
                salary.Amount = amount.Value
                salary.CompensationTypeID = compID
                _salaryService.SaveSalary(salary)
            End If
        Next

    End Sub


End Class