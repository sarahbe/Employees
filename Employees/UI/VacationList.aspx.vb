Imports System.Web.Services
Imports Employees.Entities
Imports Employees.Services

Public Class VacationList
    Inherits System.Web.UI.Page

    Private _employeeService As New EmployeeService
    Private _departmentService As New DepartmentService
    Private Shared _vacationService As New VacationService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindControls()
            Me.drpYearSelect.SelectedValue = DateTime.Now.Year
            BindRepeater()
        End If
    End Sub

    Private Sub BindControls()
        Me.drpEmployee.DataSource = _employeeService.GetAllEmployees.Where(Function(e) e.Valid)
        Me.drpEmployee.DataBind()
        BindVacations()
        BindYears()
    End Sub

    Private Sub BindVacations()
        Dim itemValues As Array = System.Enum.GetValues(GetType(Vacation.VacationTypes))
        Dim itemNames As Array = System.Enum.GetNames(GetType(Vacation.VacationTypes))

        For i As Integer = 0 To itemNames.Length - 1
            Dim item As New ListItem(itemNames(i), itemValues(i))
            Me.drpVacation.Items.Add(item)
        Next
        Me.drpVacation.DataBind()
    End Sub

    Private Sub BindYears()
        Dim thisYear = DateTime.Now.Year
        For thisYear = thisYear - 1 To DateTime.Now.Year + 3
            Me.drpYearSelect.Items.Add(Convert.ToString(thisYear))
        Next
    End Sub

    Private Sub BindRepeater()
        Me.rptVacations.DataSource = _vacationService.GetAllVacationsByMonthYear(Me.drpYearSelect.SelectedValue).Where(Function(v) v.Valid)
        Me.rptVacations.DataBind()
    End Sub
    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        Dim employeeID = Me.drpEmployee.SelectedValue.ToString
        Dim vacationType = Me.drpVacation.SelectedValue
        Dim vacationStart = Date.Parse(Request.Form("VacationStart"))
        Dim vacationEnd = Date.Parse(Request.Form("VacationEnd"))
        Dim daycal = vacationEnd - vacationStart
        Dim days = daycal.Days

        Dim LeftDays As Integer = _vacationService.GetDaysLeftByEmployee(employeeID, vacationStart.Year)
        LeftDays = LeftDays - days
        If LeftDays < 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('All vacation days are used')", True)
        End If
        Me.drpYearSelect.SelectedValue = vacationStart.Year

        Dim vacation As New Vacation
        vacation.EmployeeID = employeeID
        vacation.VacationType = Integer.Parse(vacationType)
        vacation.LeftDays = LeftDays
        vacation.Days = days
        vacation.VacationFrom = vacationStart
        vacation.VacationTo = vacationEnd
        _vacationService.SaveVacation(vacation)
        BindRepeater()

    End Sub

    Private Sub drpYearSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpYearSelect.SelectedIndexChanged
        BindRepeater()
        Me.updVacations.Update()
    End Sub

    <WebMethod>
    Public Shared Function DeleteVacation(vacationID As String) As String
        _vacationService.DeleteVacation(vacationID)
        Return "delete success"
    End Function
End Class