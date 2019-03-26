Imports Employees.Entities

Namespace Services
    Public Class DepartmentService

        Private _db As New Employees.DAL.EmployeeContext()

        Public Function GetAllDepartments() As List(Of Department)
            Dim depList As New List(Of Department)
            depList = _db.Departments.ToList
            Return depList
        End Function

        Public Sub SaveDepartment(dep As Department)
            _db.Departments.Add(dep)
            _db.SaveChanges()
        End Sub
    End Class
End Namespace

