Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class salaryChanges
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.Employees", "Salary")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Employees", "Salary", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
        End Sub
    End Class
End Namespace
