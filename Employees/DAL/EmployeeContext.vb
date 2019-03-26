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

    End Class
End Namespace

