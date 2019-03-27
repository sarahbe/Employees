<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="VacationList.aspx.vb" Inherits="Employees.VacationList" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="table-wrapper">
        <div class="table-title">
            <div class="row">
                <div class="col-sm-8">
                    <h2>Vacations</h2>
                </div>
                <div class="col-sm-4">
                    <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal">Add New Vacation</button>
                </div>
            </div>
        </div>
        <label>Month / Year</label>
        <asp:DropDownList runat="server" ID="drpMonthSelect" AutoPostBack="true"></asp:DropDownList>
        <asp:DropDownList runat="server" ID="drpYearSelect" AutoPostBack="true"></asp:DropDownList>


        <asp:UpdatePanel runat="server" ID="updVacations" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Repeater ID="rptVacations" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered" cellspacing="0" rules="all" border="1">
                            <tr>
                                <th scope="col" >Employee Name
                                </th>
                                <th scope="col">Vacation Type
                                </th>
                                <th scope="col" >Month/Year
                                </th>
                                <th scope="col" >Days
                                </th>
                                <th scope="col" >Left Days
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                          
                            <td>
                                <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("Employee.EmployeeName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblVacationType" runat="server" Text='<%# Eval("VacationType") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Month") & " / " & Eval("Year") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblDays" runat="server" Text='<%# Eval("Days") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblLeftDays" runat="server" Text='<%# Eval("LeftDays") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>


    <div class="container">
        <!-- New Vacation Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">New Vacation</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <form method="POST" action="page.aspx">
                                <div class="form-group">
                                    <label for="EmployeeName">Name</label>
                                    <asp:DropDownList runat="server" ID="drpEmployee" DataValueField="EmployeeID" DataTextField="EmployeeName"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="VacationType">Vacation Type</label>
                                    <asp:DropDownList runat="server" ID="drpVacation"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="Month">Month / Year</label>
                                    <asp:DropDownList runat="server" ID="drpMonth"></asp:DropDownList>
                                    <asp:DropDownList runat="server" ID="drpYear"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="Days">Days</label>
                                    <input type="number" class="form-control" id="Days" placeholder="Days" name="Days">
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button runat="server" onserverclick="btnAdd_ServerClick" class="btn btn-default">Add</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

