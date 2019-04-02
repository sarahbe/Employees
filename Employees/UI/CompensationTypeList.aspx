<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="CompensationTypeList.aspx.vb" Inherits="Employees.CompensationTypeList" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function deleteIt(id) {

            $.ajax({
                method: "POST",
                url: "CompensationTypeList.aspx/DeleteCompensationType",
                data: " {CompensationTypeID:'" + id + "'}",
                success: function (data) {
                    window.location.reload();
                },
                contentType: "Application/json; charset=utf-8",
                responseType: "json"
            });
        }


        $(document).ready(function () {
            //$('[data-toggle="tooltip"]').tooltip();
            var actions = $("table td:last-child").html();
            if (actions == null) {
                actions = '<a class="add" title="Add" data-toggle="tooltip"><i class="material-icons">&#xE03B;</i></a>' +
                    ' <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>'
            }
            // Append table with add row form on add new button click
            $(".add-new").click(function () {
                $(this).attr("disabled", "disabled");
                var index = $("table tbody tr:last-child").index();
                var row = '<tr>' + 
                    '<td><input type="text" class="form-control" name=-"CompensationTypeName" id="CompensationTypeName"></td>' +
                    '<td>' + actions + '</td>' +
                    '</tr>';
                $("table").append(row);

                $("table tbody tr").eq(index + 1).find(".add", ".delete").toggle();
            });
            // Add row on add button click
            $(document).on("click", ".add", function () {
                var empty = false;
                var input = $(this).parents("tr").find('input[type="text"]');

                input.each(function () {
                    if (!$(this).val()) {
                        $(this).addClass("error");
                        empty = true;
                    } else {
                        $(this).removeClass("error");
                    }
                });
                $(this).parents("tr").find(".error").first().focus();
                if (!empty) {
                    var CompensationTypeName = "";
                    input.each(function () {
                        $(this).parent("td").html($(this).val());
                        CompensationTypeName = $(this).val();
                    });
                    $.ajax({
                        method: "POST",
                        url: "CompensationTypeList.aspx/SaveCompensationType",
                        data: " {CompensationTypeName:'" + CompensationTypeName +  "'}",
                        success: console.log("success"),
                        contentType: "Application/json; charset=utf-8",
                        responseType: "json"
                    });
                    $(this).parents("tr").find(".add, .edit").toggle();
                    $(".add-new").removeAttr("disabled");
                }
            });



        });

    </script>
    <div class="table-wrapper">
        <div class="table-title">
            <div class="row">
                <div class="col-sm-8">
                    <h2>Compensation Types</h2>
                </div>
                <div class="col-sm-4">
                    <button type="button" class="btn btn-info add-new"><i class="fa fa-plus"></i>Add New Compensation Type</button>
                </div>
            </div>
        </div>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Compensation Type</th>
                    <th></th>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater ID="rtpCompensationType" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td id="CompensationType">
                                <asp:Label ID="lblCompensationType" runat="server" Text='<%# Eval("CompensationTypeName") %>' />
                            </td>
                            <td>
                                <a class="add" title="Add" data-toggle="tooltip"><i class="material-icons">&#xE03B;</i></a>
                                <a class="delete" title="Delete" data-toggle="tooltip" onclick="deleteIt('<%#Eval("CompensationTypeID") %>')"><i class="material-icons">&#xE872;</i></a>
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

