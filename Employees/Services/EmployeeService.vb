Imports System.Data.Entity.Migrations
Imports Employees.Entities

Namespace Services
    Public Class EmployeeService

        Private _db As New Employees.DAL.EmployeeContext()

        Public Function GetAllEmployees() As List(Of Employee)
            Dim empList As New List(Of Employee)
            empList = _db.Employees.Include("Department").ToList
            Return empList
        End Function

        Public Function GetEmployee(empID As Integer) As Employee
            Dim emp As New Employee
            emp = _db.Employees.FirstOrDefault(Function(e) e.EmployeeID.Equals(empID))
            Return emp
        End Function

        Public Sub SaveEmployee(emp As Employee)
            'If emp.EmployeeID <> Nothing Then

            'End If
            _db.Employees.AddOrUpdate(emp)
            _db.SaveChanges()
        End Sub

        Public Sub DeleteEmployee(empId As Integer)
            Dim emp = _db.Employees.FirstOrDefault(Function(e) e.EmployeeID.Equals(empId))
            emp.Valid = False
            _db.Employees.AddOrUpdate(emp)
            _db.SaveChanges()
        End Sub
    End Class
End Namespace

