$(document).ready(function () {
    //$('[data-toggle="tooltip"]').tooltip();
    var actions = $("table td:last-child").html();
    if (actions == null) {
    actions = '<a class="add" title="Add" data-toggle="tooltip"><i class="material-icons">&#xE03B;</i></a>' + 
            '<a class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a>'+
           ' <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>'
    }
    console.log(actions);
    debugger;
    // Append table with add row form on add new button click
    $(".add-new").click(function () {
        $(this).attr("disabled", "disabled");
        var index = $("table tbody tr:last-child").index();
        var row = '<tr>' + '<td><input type="hidden" class="form-control" name="DepartmentId" id="DepartmentId"></td>' +
            '<td><input type="text" class="form-control" name="DepartmentName" id="DepartmentName"></td>' +
            '<td>' + actions + '</td>' +
            '</tr>';
        $("table").append(row);
      
        $("table tbody tr").eq(index + 1).find(".add, .edit").toggle();
    });
    // Add row on add button click
    $(document).on("click", ".add", function () {
        var empty = false;
        var input = $(this).parents("tr").find('input[type="text"]');
        var idField= $(this).parents("tr").find('input[type="hidden"]');

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
            var departmentName = "";
            var departmentId = idField.val();
            console.log(departmentId);
            input.each(function () {
                $(this).parent("td").html($(this).val());
                departmentName = $(this).val();
            });
            $.ajax({
                method: "POST",
                url: "DepartmentList.aspx/SaveDepartment",
                data: " {DepartmentName:'" + departmentName + "',DepartmentId:'"+ departmentId + "'}",
                success: console.log("success"),
                contentType: "Application/json; charset=utf-8",
                responseType: "json"
            });
            $(this).parents("tr").find(".add, .edit").toggle();
            $(".add-new").removeAttr("disabled");
        }
    });
    // Edit row on edit button click
    $(document).on("click", ".edit", function () {
        $(this).parents("tr").find("#department").each(function () {
            $(this).html('<input type="text" class="form-control" value="' + $.trim($(this).text()) + '">');
        });
        $(this).parents("tr").find("#departmentID").each(function () {
            $(this).html('<input type="hidden" class="form-control" value="' + $.trim( $(this).text() )+ '">');
            //console.log($(this).text());
        })
        $(this).parents("tr").find(".add, .edit").toggle();
        $(".add-new").attr("disabled", "disabled");
    });
    

    // Delete row on delete button click
   

    $(document).on("click", ".delete", function () {
        var idField = $(this).parents("tr").find("#departmentID").text();
        debugger;
        //var departmentId = idField.val();
        $.ajax({
            method: "POST",
            url: "DepartmentList.aspx/DeleteDepartment",
            data: " {DepartmentId:'" + $.trim(idField) + "'}",
            success: console.log("delete"),
            contentType: "Application/json; charset=utf-8",
            responseType: "json"
        });
        $(this).parents("tr").remove();
        $(".add-new").removeAttr("disabled");
    });
});