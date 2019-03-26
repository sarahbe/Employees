Imports Employees.Entities

Namespace Services
    Public Class VacationService

        Private _db As New Employees.DAL.EmployeeContext()

        Public Function GetAllVacationsByMonthYear(month As String, year As Integer) As List(Of Vacation)
            Dim vacList As New List(Of Vacation)
            vacList = _db.Vacations.Include("Employee").Where(Function(v) v.Month.Equals(month) AndAlso v.Year.Equals(year)).ToList
            Return vacList
        End Function

        Public Function GetDaysLeftByEmployee(employeeID As Integer, year As Integer) As Integer
            Dim employeeVacations = _db.Vacations.Where(Function(v) v.EmployeeID.Equals(employeeID) AndAlso v.Year.Equals(year))
            Dim leftVac = 0
            If employeeVacations.Count > 0 Then
                leftVac = employeeVacations.OrderByDescending(Function(e) e.VacationID).FirstOrDefault.LeftDays
            Else
                leftVac = 30
            End If
            Return leftVac
        End Function

        Public Sub SaveVacation(vac As Vacation)
            _db.Vacations.Add(vac)
            _db.SaveChanges()
        End Sub
    End Class
End Namespace

