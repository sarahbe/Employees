Namespace Entities
    Public Class Employee

        Public Property EmployeeID() As Integer
        Public Property EmployeeName() As String
        Public Property Birthdate() As Date = DateTime.Now
        Public Property Email() As String
        Public Property MobileNo() As String
        Public Property DepartmentID() As Integer
        Public Property Valid As Boolean = True
        Public Property Salary As Decimal

        Private _department As Department
        Public Property Department() As Department
            Get
                Return _department
            End Get
            Private Set(ByVal value As Department)
                _department = value
            End Set
        End Property


    End Class
End Namespace

