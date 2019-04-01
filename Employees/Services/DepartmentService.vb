Imports Employees.Entities
Imports System.Data.Entity.Migrations

Namespace Services
    Public Class DepartmentService

        Private _db As New Employees.DAL.EmployeeContext()

        Public Function GetAllDepartments() As List(Of Department)
            Dim depList As New List(Of Department)
            depList = _db.Departments.ToList
            Return depList
        End Function

        Public Sub SaveDepartment(dep As Department)
            _db.Departments.AddOrUpdate(dep)
            _db.SaveChanges()
        End Sub

        Public Function GetDepartment(depID As Integer) As Department
            Dim dep As New Department
            dep = _db.Departments.FirstOrDefault(Function(e) e.DepartmentID.Equals(depID))
            Return dep
        End Function

        Public Sub DeleteDepartment(depId As Integer)
            Dim dep = _db.Departments.FirstOrDefault(Function(e) e.DepartmentID.Equals(depId))
            dep.Valid = False
            _db.Departments.AddOrUpdate(dep)
            _db.SaveChanges()
        End Sub

        Friend Function GetDepartmentByName(departmentName As String) As List(Of Department)
            Return _db.Departments.Where(Function(x) String.Equals(x.DepartmentName, departmentName, StringComparison.CurrentCultureIgnoreCase)).ToList()
        End Function
    End Class
End Namespace

