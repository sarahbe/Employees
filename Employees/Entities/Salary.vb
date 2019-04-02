Imports Employees.Services

Namespace Entities
    Public Class Salary
        Private _employeeService As New EmployeeService
        Private _salaryService As New SalaryService


        Public Property SalaryID As Integer
        Public Property CompensationTypeID As Integer
        Public Property EmployeeID As Integer
        Public Property Amount As Decimal = 0.0
        Public Property Valid As Boolean = True

        Private _employee As New Employee
        Public ReadOnly Property Employee() As Employee
            Get
                Return _employeeService.GetEmployee(EmployeeID)
            End Get
        End Property

        Private _compensationtype As New CompensationType
        Public ReadOnly Property CompensationType() As CompensationType
            Get
                Return _salaryService.GetCompenstationType(CompensationTypeID)
            End Get
        End Property
    End Class
End Namespace

