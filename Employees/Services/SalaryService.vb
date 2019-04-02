Imports System.Data.Entity.Migrations
Imports Employees.Entities

Namespace Services
    Public Class SalaryService
        Private _db As New Employees.DAL.EmployeeContext()

        Public Function GetAllCompenstationTypes() As List(Of CompensationType)
            Dim comList As New List(Of CompensationType)
            comList = _db.CompensationTypes.ToList
            Return comList
        End Function

        Public Sub SaveCompensationType(com As CompensationType)
            _db.CompensationTypes.Add(com)
            _db.SaveChanges()
        End Sub

        Public Sub DeleteCompensationType(comId As Integer)
            Dim com = _db.CompensationTypes.FirstOrDefault(Function(e) e.CompensationTypeID.Equals(comId))
            com.Valid = False
            _db.CompensationTypes.AddOrUpdate(com)
            _db.SaveChanges()
        End Sub
    End Class

End Namespace
