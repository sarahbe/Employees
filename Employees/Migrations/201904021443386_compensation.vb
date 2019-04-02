Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class compensation
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.CompensationTypes",
                Function(c) New With
                    {
                        .CompensationTypeID = c.Int(nullable := False, identity := True),
                        .CompensationTypeName = c.String(),
                        .Valid = c.Boolean(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.CompensationTypeID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.CompensationTypes")
        End Sub
    End Class
End Namespace
