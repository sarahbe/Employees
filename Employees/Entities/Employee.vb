Imports Employees.Services

Namespace Entities
    Public Class Employee
        Private _salaryService As New SalaryService

        Public Property EmployeeID() As Integer
        Public Property EmployeeName() As String
        Public Property Birthdate() As Date = DateTime.Now
        Public Property Email() As String
        Public Property MobileNo() As String
        Public Property DepartmentID() As Integer
        Public Property Valid As Boolean = True
        'Public Property Salary As Decimal

        Private _department As Department
        Public Property Department() As Department
            Get
                Return _department
            End Get
            Private Set(ByVal value As Department)
                _department = value
            End Set
        End Property


        Public Overridable ReadOnly Property Salary() As Decimal
            Get
                Return _salaryService.GetSalaryByEmployee(EmployeeID).Where(Function(d) d.CompensationType.Valid).Sum(Function(a) a.Amount)
            End Get
        End Property


    End Class
End Namespace

