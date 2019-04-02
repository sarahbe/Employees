Imports System.Data.Entity
Imports Employees.Entities

Namespace DAL
    Public Class EmployeeContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("Employee")
        End Sub

        Public Property Departments As DbSet(Of Department)
        Public Property Employees As DbSet(Of Employee)
        Public Property Vacations As DbSet(Of Vacation)
        Public Property CompensationTypes As DbSet(Of CompensationType)
        Public Property Salaries As DbSet(Of Salary)
    End Class
End Namespace

