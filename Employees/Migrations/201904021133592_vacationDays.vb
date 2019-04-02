Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class vacationDays
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Vacations", "VacationFrom", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.Vacations", "VacationTo", Function(c) c.DateTime(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Vacations", "VacationTo")
            DropColumn("dbo.Vacations", "VacationFrom")
        End Sub
    End Class
End Namespace
