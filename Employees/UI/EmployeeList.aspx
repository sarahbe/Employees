<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="EmployeeList.aspx.vb" Inherits="Employees.EmployeeList" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
     
        $(document).ready(function () {
            var drpDep = document.getElementById("<%=drpDep.ClientID %>");

            $(document).on("click", ".delete", function (e) {
                var deleteButton = $(e.target);
                var labelEmployeeId = deleteButton.parents("tr").find(".lblEmployeeId").html();
                console.log(labelEmployeeId);
                console.log(deleteButton.parents("tr").find(".lblEmployeeId"));
                $("#EmployeeIdHd").val(labelEmployeeId);

                $("#formType").val("delete");
                $("#MainContent_btnAdd").trigger("click")

                console.log($("#MainContent_btnAdd"))
                console.log($("#EmployeeForm"))

            });
            $('#myModal').on('shown.bs.modal', function (e) {

                console.log(drpDep.value)
                if (drpDep.value == "") {
                    e.stopPropagation();
                    $('#myModal').modal('hide');
                    alert("please make sure to add new department first!")
                    exit();
                }

                var editButton = $(e.relatedTarget);
                var labelEmployyName = editButton.parents("tr").find(".lblEmployeeName").html();
                $("#EmployeeName").val(labelEmployyName);

                var labelEmployeeId = editButton.parents("tr").find(".lblEmployeeId").html();
                $("#EmployeeIdHd").val(labelEmployeeId);

                var labelEmployeeDate = editButton.parents("tr").find(".lblBirthdate").html();
                $("#Birthdate").val(labelEmployeeDate);

                var labelEmployeeMobile = editButton.parents("tr").find(".lblMobile").html();
                $("#MobileNo").val(labelEmployeeMobile);

                var labelEmployeeEmail = editButton.parents("tr").find(".lblEmail").html();
                $("#Email").val(labelEmployeeEmail);

                var labelEmployeeSalary = editButton.parents("tr").find(".lblSalary").html();
                $("#Salary").val(labelEmployeeSalary);

                var labelEmployeDepartment = editButton.parents("tr").find(".lblDepartment").html();
                $("#DepartmentID").val(labelEmployeDepartment);
                $("#formType").val("edit");


            })

        });

    </script>
    <div class="table-wrapper">
        <div class="table=title">
            <div class="row">
                <div class="col-sm-8">
                    <h2>Employee</h2>
                </div>
                <div class="col-sm-4">
                    <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal">Add New Employee</button>
                </div>
            </div>
        </div>
        <asp:Repeater ID="rptEmployee" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered" cellspacing="0" rules="all" border="1">
                    <tr>
                        <th></th>
                        <th scope="col">Employee Id
                        </th>
                        <th scope="col">Employee Name
                        </th>
                        <th scope="col">Birthdate
                        </th>
                        <th scope="col" style="width: 200px">Email
                        </th>
                        <th scope="col">Mobile
                        </th>
                        <th scope="col">Department
                        </th>
                        <th scope="col">Salary</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="<%# GetClassForColor(Container.DataItem) %>">
                    <td><a class="edit" title="Edit" data-toggle="modal" data-target="#myModal"><i class="material-icons">&#xE254;</i></a>
                        <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a></td>

                    <td id="emp">
                        <asp:Label ID="lblEmployeeId" CssClass="lblEmployeeId" runat="server" Text='<%# Eval("EmployeeID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblEmployeeName" CssClass="lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblBirthdate" CssClass="lblBirthdate" runat="server" Text='<%# Eval("Birthdate", "{0:yyyy-MM-dd}") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" CssClass="lblEmail" runat="server" Text='<%# Eval("Email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblMobile" CssClass="lblMobile" runat="server" Text='<%# Eval("MobileNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblDepartment" CssClass="lblDepartment" runat="server" Text='<%# Eval("Department.DepartmentName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblSalary" CssClass="lblSalary" runat="server" Text='<%# Eval("Salary") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>


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
                            <form method="POST" id="EmployeeForm" action="page.aspx">
                                <input type="hidden" id="EmployeeIdHd" name="EmployeeIdHd" />
                                <div class="form-group">
                                    <label for="EmployeeName">Name</label>
                                    <input type="text" class="form-control" id="EmployeeName" placeholder="Enter Name" name="EmployeeName">
                                </div>
                                <div class="form-group">
                                    <label for="Birthdate">Birth</label>
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
                                <div class="form-group">
                                    <label for="Salary">Salary</label>
                                    <input type="tel" class="form-control" id="Salary" placeholder="Salary" name="Salary">
                                </div>
                                <asp:DropDownList runat="server" ID="drpDep" DataValueField="DepartmentID" DataTextField="DepartmentName"></asp:DropDownList>
                                <input type="hidden" value="edit" id="formType" name="formType" />
                            </form>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button runat="server" id="btnAdd" onserverclick="btnAdd_ServerClick" class="btn btn-default">Add</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
