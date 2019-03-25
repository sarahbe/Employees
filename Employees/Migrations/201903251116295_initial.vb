Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Departments",
                Function(c) New With
                    {
                        .DepartmentID = c.Int(nullable := False, identity := True),
                        .DepartmentName = c.String()
                    }) _
                .PrimaryKey(Function(t) t.DepartmentID)
            
            CreateTable(
                "dbo.Employees",
                Function(c) New With
                    {
                        .EmployeeID = c.Int(nullable := False, identity := True),
                        .EmployeeName = c.String(),
                        .DepartmentID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.EmployeeID) _
                .ForeignKey("dbo.Departments", Function(t) t.DepartmentID, cascadeDelete := True) _
                .Index(Function(t) t.DepartmentID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments")
            DropIndex("dbo.Employees", New String() { "DepartmentID" })
            DropTable("dbo.Employees")
            DropTable("dbo.Departments")
        End Sub
    End Class
End Namespace
