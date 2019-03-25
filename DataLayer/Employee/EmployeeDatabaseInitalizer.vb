Imports System.Collections.Generic
Imports System.Data.Entity

Namespace DataLayer
    Public Class ProductDatabaseInitializer
        Inherits DropCreateDatabaseIfModelChanges(Of EmployeeContext)

        Protected Overrides Sub Seed(ByVal context As EmployeeContext)
            GetDepartments().ForEach(Sub(c) context.Departments.Add(c))
            GetEmployees().ForEach(Sub(p) context.Employees.Add(p))
        End Sub

        Private Shared Function GetDepartments() As List(Of Department)
            Dim departments = New List(Of Department) From {
                New Department With {
                    .DepartmentID = 1,
                    .DepartmentName = "Finance"
                },
               New Department With {
                    .DepartmentID = 2,
                    .DepartmentName = "IT"
                }
            }
            Return departments
        End Function

        Private Shared Function GetEmployees() As List(Of Employee)
            Dim employees = New List(Of Employee) From {
                New Employee With {
                    .EmployeeID = 1,
                    .EmployeeName = "Sarah Bayrakdar",
                    .DepartmentID = 1
                },
              New Employee With {
                    .EmployeeID = 2,
                    .EmployeeName = "Ahmad Ahmad",
                    .DepartmentID = 2
                }
            }
            Return employees
        End Function
    End Class
End Namespace
