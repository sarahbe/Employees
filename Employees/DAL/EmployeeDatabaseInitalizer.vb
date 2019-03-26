Imports System.Collections.Generic
Imports System.Data.Entity
Imports Employees.Entities

Namespace DAL
    Public Class EmployeeDatabaseInitializer
        Inherits CreateDatabaseIfNotExists(Of EmployeeContext)

        Protected Overrides Sub Seed(ByVal context As EmployeeContext)
            GetDepartments().ForEach(Sub(c) context.Departments.Add(c))
            GetEmployees().ForEach(Sub(p) context.Employees.Add(p))
            context.SaveChanges()
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
                    .Birthdate = Date.Parse("01/01/1990"),
                    .MobileNo = "0568880051",
                    .Email = "sarah@gmail.com",
                    .DepartmentID = 1
                },
              New Employee With {
                    .EmployeeID = 2,
                    .EmployeeName = "Ahmad Ahmad",
                    .Birthdate = Date.Parse("25/05/1985"),
                    .MobileNo = "012345678",
                    .Email = "ahmad@gmail.com",
                    .DepartmentID = 2
                }
            }
            Return employees
        End Function
    End Class
End Namespace
