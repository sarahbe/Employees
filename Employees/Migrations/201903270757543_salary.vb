Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class salary
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Employees", "Salary", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Employees", "Salary")
        End Sub
    End Class
End Namespace
