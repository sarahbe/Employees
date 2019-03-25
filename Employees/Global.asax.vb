Imports System.Web.Optimization
Imports System.Data.Entity
Imports Employees.DAL

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        'Initialize the employee database.
        Database.SetInitializer(New EmployeeDatabaseInitializer())
    End Sub
End Class