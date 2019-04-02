<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="SalaryCalculation.aspx.vb" Inherits="Employees.SalaryCalculation" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>

</script>
    <div class="table-wrapper">
        <div class="table-title">
            <div class="row">
                <div class="col-sm-8">
                    <h2>Salary Breakdown</h2>
                </div>
                <div class="col-sm-4">
                    <button type="button" runat="server" id="btnSave" class="btn btn-info add-new"><i class="fa fa-plus"></i>Save</button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-8">

                <label>Please Select an Employee</label>
                <asp:DropDownList runat="server" ID="drpEmployee" DataTextField="EmployeeName" DataValueField="EmployeeID" AutoPostBack="true"></asp:DropDownList>

            </div>

        </div>


        <asp:UpdatePanel runat="server" ID="updSalary" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Repeater ID="rptSalary" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered" cellspacing="0" rules="all" border="1">
                            <tr>
                                <th scope="col">Compensation Type
                                </th>
                                <th scope="col">Amount
                                </th>

                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField runat="server" ID="hdnIdSalary" Value='<%# Eval("SalaryID") %>' />
                            <asp:HiddenField runat="server" ID="hdnIdComp" Value='<%# Eval("CompensationType.CompensationTypeID") %>' />
                            <td>
                                <asp:Label ID="lblCompensationType" runat="server" Text='<%# Eval("CompensationType.CompensationTypeName") %>' />
                            </td>
                            <td>
                                <%--<asp:TextBox   runat="server" ID="Amount" Text='<%# Eval("Amount") %>'></asp:TextBox>--%>
                                <input runat="server" type="number" class="form-control" name="Amount" id="Amount" value='<%# Eval("Amount") %>'>
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
</asp:Content>

