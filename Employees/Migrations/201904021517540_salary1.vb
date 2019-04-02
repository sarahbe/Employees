Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class salary1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Salaries",
                Function(c) New With
                    {
                        .SalaryID = c.Int(nullable := False, identity := True),
                        .CompensationTypeID = c.Int(nullable := False),
                        .EmployeeID = c.Int(nullable := False),
                        .Amount = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Valid = c.Boolean(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.SalaryID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Salaries")
        End Sub
    End Class
End Namespace
