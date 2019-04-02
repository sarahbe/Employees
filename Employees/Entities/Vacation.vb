Imports Employees.Services

Namespace Entities
    Public Class Vacation
        Private _employeeService As New EmployeeService


        Public Enum VacationTypes
            Annual = 1
            Sick = 2
            Other = 3
        End Enum

        Public Enum Months
            Jan = 1
            Feb = 2
            March = 3
            Apr = 4
            May = 5
            June = 6
            Jul = 7
            Aug = 8
            Spt = 9
            Oct = 10
            Nov = 11
            Dec = 12
        End Enum


        Public Property VacationID As Integer
        Public Property VacationType As VacationTypes
        Public Property EmployeeID() As Integer
        Public Property Days As Integer
        Public Property LeftDays As Integer
        Public Property VacationFrom() As Date = DateTime.Now
        Public Property VacationTo() As Date = DateTime.Now

        Public Property Month As String
        Public Property Year As Integer
        Public Property Valid As Boolean = True

        'Public Property Employee As Employee

        Private _employee As New Employee
        Public ReadOnly Property Employee() As Employee
            Get
                Return _employeeService.GetEmployee(EmployeeID)
            End Get
        End Property
    End Class

End Namespace

