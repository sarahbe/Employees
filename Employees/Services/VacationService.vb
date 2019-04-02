Imports System.Data.Entity.Migrations
Imports Employees.Entities

Namespace Services
    Public Class VacationService

        Private _db As New Employees.DAL.EmployeeContext()

        Public Function GetAllVacationsByMonthYear(year As Integer) As List(Of Vacation)
            Dim vacList As New List(Of Vacation)
            If _db.Vacations.Any Then
                vacList = _db.Vacations.Where(Function(v) v.VacationFrom.Year.Equals(year)).ToList
            End If
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

        Public Sub DeleteVacation(vacID As Integer)
            Dim vac = _db.Vacations.FirstOrDefault(Function(v) v.VacationID.Equals(vacID))
            vac.Valid = False
            _db.Vacations.AddOrUpdate(vac)
            _db.SaveChanges()
        End Sub
    End Class
End Namespace

