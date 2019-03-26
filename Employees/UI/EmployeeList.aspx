<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="EmployeeList.aspx.vb" Inherits="Employees.EmployeeList" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Employee</h2>
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
                            <th scope="col" style="width: 100px">Year Birth
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblCustomerId" runat="server" Text='<%# Eval("EmployeeID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("EmployeeName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("YearBirth") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>


            <div class="container">
                <h2>Employee</h2>
                <!-- Trigger the modal with a button -->
                <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add New Employee</button>

                <!-- Modal -->
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">New Employee</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">
                                    <form  method="POST" action="page.aspx">
                                        <div class="form-group">
                                            <label for="EmployeeName">Name</label>
                                            <input type="text" class="form-control" id="EmployeeName" placeholder="Enter Name" name="EmployeeName">
                                        </div>
                                        <div class="form-group">
                                            <label for="YearBirth">Year Birth</label>
                                            <input type="date" class="form-control" id="YearBirth" name="YearBirth">
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
