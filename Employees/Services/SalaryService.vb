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

        Public Function GetCompenstationType(id As Integer) As CompensationType
            Dim com As New CompensationType
            com = _db.CompensationTypes.FirstOrDefault(Function(e) e.CompensationTypeID.Equals(id))
            Return com
        End Function

        Public Function GetSalary(id As Integer) As Salary
            Dim sal As New Salary
            sal = _db.Salaries.FirstOrDefault(Function(e) e.SalaryID.Equals(id))
            Return sal
        End Function

        Public Function GetSalaryByEmployee(id As Integer?) As List(Of Salary)
            Dim sal = New List(Of Salary)
            If id.HasValue Then
                sal = _db.Salaries.Where(Function(e) e.EmployeeID.Equals(id)).ToList
                If sal.Count = 0 Then
                    For Each com In _db.CompensationTypes.Where(Function(c) c.Valid)
                        sal.Add(New Salary With {.CompensationTypeID = com.CompensationTypeID, .Valid = True})
                    Next
                End If
            End If
            Return sal
        End Function


        Public Sub SaveCompensationType(com As CompensationType)
            _db.CompensationTypes.Add(com)
            _db.SaveChanges()
        End Sub

        Public Sub SaveSalary(sal As Salary)
            _db.Salaries.AddOrUpdate(sal)
            _db.SaveChanges()
        End Sub

        Public Sub DeleteSalary(sal As Salary)
            sal.Valid = False
            _db.Salaries.AddOrUpdate(sal)
            _db.SaveChanges()
        End Sub

        Public Sub DeleteCompensationType(comId As Integer)
            Dim com = _db.CompensationTypes.FirstOrDefault(Function(e) e.CompensationTypeID.Equals(comId))
            com.Valid = False
            Dim salaryList As List(Of Salary) = _db.Salaries.Where(Function(s) s.CompensationTypeID.Equals(comId) AndAlso s.Valid)
            For Each sl In salaryList
                DeleteSalary(sl)
            Next
            _db.CompensationTypes.AddOrUpdate(com)
            _db.SaveChanges()
        End Sub
    End Class

End Namespace
