<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="DepartmentList.aspx.vb" Inherits="Employees.DepartmentList" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../Scripts/DepartmentTable.js"></script>


    <div class="table-wrapper">
        <div class="table-title">
            <div class="row">
                <div class="col-sm-8">
                    <h2>Departments</h2>
                </div>
                <div class="col-sm-4">
                    <button type="button" class="btn btn-info add-new"><i class="fa fa-plus"></i>Add New</button>
                </div>
            </div>
        </div>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th >Department</th>
                    <th ></th>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater ID="rtpDepartment" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td id="departmentID">
                                <asp:Label ID="lblDepartmentId" runat="server" Text='<%#Eval("DepartmentID") %>' />
                            </td>
                            <td id="department">
                                <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DepartmentName") %>' />
                            </td>
                            <td>
                                <a class="add" title="Add" data-toggle="tooltip"><i class="material-icons">&#xE03B;</i></a>
                                <a class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a>
                                <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

            </tbody>

        </table>
    </div>

</asp:Content>

