﻿<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="DepartmentList.aspx.vb" Inherits="Employees.DepartmentList" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round|Open+Sans">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            //$('[data-toggle="tooltip"]').tooltip();
            var actions = $("table td:last-child").html();
            // Append table with add row form on add new button click
            $(".add-new").click(function () {
                $(this).attr("disabled", "disabled");
                var index = $("table tbody tr:last-child").index();
                var row = '<tr>' +
                    '<td><input type="text" class="form-control" name="DepartmentName" id="DepartmentName"></td>' +
                    '<td>' + actions + '</td>' +
                    '</tr>';
                $("table").append(row);
                $("table tbody tr").eq(index + 1).find(".add, .edit").toggle();
                //$('[data-toggle="tooltip"]').tooltip();
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
                    input.each(function () {
                        $(this).parent("td").html($(this).val());
                    });
                    $(this).parents("tr").find(".add, .edit").toggle();
                    $(".add-new").removeAttr("disabled");
                }
            });
            // Edit row on edit button click
            $(document).on("click", ".edit", function () {
                $(this).parents("tr").find("td:not(:last-child)").each(function () {
                    $(this).html('<input type="text" class="form-control" value="' + $(this).text() + '">');
                });
                $(this).parents("tr").find(".add, .edit").toggle();
                $(".add-new").attr("disabled", "disabled");
            });
            // Delete row on delete button click
            $(document).on("click", ".delete", function () {
                $(this).parents("tr").remove();
                $(".add-new").removeAttr("disabled");
            });
        });
    </script>
    <style type="text/css">
        body {
            color: #404E67;
            background: #F5F7FA;
            font-family: 'Open Sans', sans-serif;
        }

        .table-wrapper {
            width: 700px;
            margin: 30px auto;
            background: #fff;
            padding: 20px;
            box-shadow: 0 1px 1px rgba(0,0,0,.05);
        }

        .table-title {
            padding-bottom: 10px;
            margin: 0 0 10px;
        }

            .table-title h2 {
                margin: 6px 0 0;
                font-size: 22px;
            }

            .table-title .add-new {
                float: right;
                height: 30px;
                font-weight: bold;
                font-size: 12px;
                text-shadow: none;
                min-width: 100px;
                border-radius: 50px;
                line-height: 13px;
            }

                .table-title .add-new i {
                    margin-right: 4px;
                }

        table.table {
            table-layout: fixed;
        }

            table.table tr th, table.table tr td {
                border-color: #e9e9e9;
            }

            table.table th i {
                font-size: 13px;
                margin: 0 5px;
                cursor: pointer;
            }

            table.table th:last-child {
                width: 100px;
            }

            table.table td a {
                cursor: pointer;
                display: inline-block;
                margin: 0 5px;
                min-width: 24px;
            }

                table.table td a.add {
                    color: #27C46B;
                }

                table.table td a.edit {
                    color: #FFC107;
                }

                table.table td a.delete {
                    color: #E34724;
                }

            table.table td i {
                font-size: 19px;
            }

            table.table td a.add i {
                font-size: 24px;
                margin-right: -1px;
                position: relative;
                top: 3px;
            }

            table.table .form-control {
                height: 32px;
                line-height: 32px;
                box-shadow: none;
                border-radius: 2px;
            }

                table.table .form-control.error {
                    border-color: #f50000;
                }

            table.table td .add {
                display: none;
            }
    </style>

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
                    <th style="width:100px">ID</th>
                    <th style="width:200px">Department</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater ID="rtpDepartment" runat="server">
                    <ItemTemplate>
                        <tr >
                            <td>
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
