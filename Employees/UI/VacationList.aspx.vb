Imports Employees.Entities
Imports Employees.Services

Public Class VacationList
    Inherits System.Web.UI.Page

    Private _employeeService As New EmployeeService
    Private _departmentService As New DepartmentService
    Private _vacationService As New VacationService

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
        BindMonths()
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

    Private Sub BindMonths()
        Dim itemValues As Array = System.Enum.GetValues(GetType(Vacation.Months))
        Dim itemNames As Array = System.Enum.GetNames(GetType(Vacation.Months))

        For i As Integer = 0 To itemNames.Length - 1
            Dim item As New ListItem(itemNames(i), itemValues(i))
            Me.drpMonth.Items.Add(item)
            Me.drpMonthSelect.Items.Add(item)
        Next
        Me.drpMonth.DataBind()
        Me.drpMonthSelect.DataBind()
    End Sub

    Private Sub BindYears()
        Dim thisYear = DateTime.Now.Year
        For thisYear = thisYear - 1 To DateTime.Now.Year + 3
            Me.drpYear.Items.Add(Convert.ToString(thisYear))
            Me.drpYearSelect.Items.Add(Convert.ToString(thisYear))
        Next
    End Sub

    Private Sub BindRepeater()
        Me.rptVacations.DataSource = _vacationService.GetAllVacationsByMonthYear(Me.drpMonthSelect.SelectedValue, Me.drpYearSelect.SelectedValue)
        Me.rptVacations.DataBind()
    End Sub
    Protected Sub btnAdd_ServerClick(sender As Object, e As EventArgs)
        Dim employeeID = Me.drpEmployee.SelectedValue.ToString
        Dim vacationType = Me.drpVacation.SelectedValue
        Dim month = Me.drpMonth.SelectedValue.ToString
        Dim year = Me.drpYear.SelectedValue.ToString
        Dim days = Request.Form("Days")
        Dim LeftDays As Integer = _vacationService.GetDaysLeftByEmployee(employeeID, year)
        LeftDays = LeftDays - days
        If LeftDays < 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('All vacation days are used')", True)
        End If
        Me.drpMonthSelect.SelectedValue = month
        Me.drpYearSelect.SelectedValue = year

        Dim vacation As New Vacation
        vacation.EmployeeID = employeeID
        vacation.VacationType = Integer.Parse(vacationType)
        vacation.Month = month
        vacation.Year = year
        vacation.LeftDays = LeftDays
        vacation.Days = days
        _vacationService.SaveVacation(vacation)
        BindRepeater()

    End Sub

    Private Sub drpMonthSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpMonthSelect.SelectedIndexChanged
        BindRepeater()
        Me.updVacations.Update()
    End Sub

    Private Sub drpYearSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpYearSelect.SelectedIndexChanged
        BindRepeater()
        Me.updVacations.Update()
    End Sub
End Class