

Imports System.Data.Entity

Namespace DataLayer
    Public Class EmployeeContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("EmployeeDB")
        End Sub

        Public Property Departments As DbSet(Of Department)
        Public Property Employees As DbSet(Of Employee)

    End Class
End Namespace

