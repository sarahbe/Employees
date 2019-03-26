<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="EmployeeList.aspx.vb" Inherits="Employees.EmployeeList" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Employee</h2>
    <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal">Add New Employee</button>

    <div>
        <div class="container">
            <asp:Repeater ID="rptEmployee" runat="server">
                <HeaderTemplate>
                    <table cellspacing="0" rules="all" border="1">
                        <tr>
                            <th scope="col" style="width: 80px">Employee Id
                            </th>
                            <th scope="col" style="width: 120px">Employee Name
                            </th>
                            <th scope="col" style="width: 100px">Birthdate
                            </th>
                            <th scope="col" style="width: 100px">Email
                            </th>
                            <th scope="col" style="width: 100px">Mobile
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmployeeId" runat="server" Text='<%# Eval("EmployeeID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblBirthdate" runat="server" Text='<%# Eval("Birthdate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("MobileNo") %>' />
                        </td>
                        <td></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>


            <div class="container">
                <!-- New Employee Modal -->
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">New Employee</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">
                                    <form method="POST" action="page.aspx">
                                        <div class="form-group">
                                            <label for="EmployeeName">Name</label>
                                            <input type="text" class="form-control" id="EmployeeName" placeholder="Enter Name" name="EmployeeName">
                                        </div>
                                        <div class="form-group">
                                            <label for="Birthdate">Year Birth</label>
                                            <input type="date" class="form-control" id="Birthdate" name="Birthdate">
                                        </div>
                                        <div class="form-group">
                                            <label for="Email">Email</label>
                                            <input type="email" class="form-control" id="Email" placeholder="Email" name="Email">
                                        </div>
                                        <div class="form-group">
                                            <label for="MobileNo">Mobile No</label>
                                            <input type="tel" class="form-control" id="MobileNo" placeholder="MobileNo" name="MobileNo">
                                        </div>
                                        <asp:DropDownList runat="server" ID="drpDep" DataValueField="DepartmentID" DataTextField="DepartmentName"></asp:DropDownList>

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

        </div>
    </div>

</asp:Content>
