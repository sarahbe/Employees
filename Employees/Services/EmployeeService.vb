Imports Employees.Entities

Namespace Services
    Public Class EmployeeService

        Private _db As New Employees.DAL.EmployeeContext()

        Public Function GetAllEmployees() As List(Of Employee)
            Dim empList As New List(Of Employee)
            empList = _db.Employees.ToList
            Return empList
        End Function

        Public Sub SaveEmployee(emp As Employee)
            _db.Employees.Add(emp)
            _db.SaveChanges()
        End Sub
    End Class
End Namespace

