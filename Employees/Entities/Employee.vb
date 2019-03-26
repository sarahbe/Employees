Namespace Entities
    Public Class Employee

        Public Property EmployeeID() As Integer

        Public Property EmployeeName() As String
        Public Property YearBirth() As Integer

        Public Property DepartmentID() As Integer


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

