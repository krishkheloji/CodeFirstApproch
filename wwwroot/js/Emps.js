$(document).ready(function () {
    FetchEmpDetails();
});

$("#modalbtn").click(function () {
    $("#exampleModal").modal('show');
    $("#id_div").hide();
    $("#savebtn").show();
    $("#updbtn").hide();
});


$("#savebtn").click(function () {
    var obj = $("#empdets").serialize();

    $.ajax({
        url: '/EmployeeHandler/AddEmployees',
        type: 'Post',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        data: obj,
        success: function () {
            alert('Added Success');
            $("#exampleModal").modal('hide');
            FetchEmpDetails();
        },
        error: function () {
            alert('not');
        }
    });
});

function FetchEmpDetails()
{
    $.ajax({
        url: '/EmployeeHandler/FetchEmps',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (res) {
            var ob = '';
            $.each(res, function (index, item) {
                ob += '<tr>';
                ob += `<td>${item.eid}</td>`;
                ob += `<td>${item.ename}</td>`;
                ob += `<td>${item.email}</td>`;
                ob += `<td>${item.esalary}</td>`;
                ob += `<td>${item.managerName}</td>`;
                ob += '<td><a class="btn btn-sm btn-success" onclick="EditEmp('+item.eid+')">Edit</a></td>';
                ob += '</tr>';
            });
            $("#empdata").html(ob);
        },
        error: function () {
            alert('not');
        }
    });
}

function EditEmp(id)
{
    $.ajax({
        url: '/EmployeeHandler/EditEmployees?eid='+id,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (res) {
            $("#exampleModal").modal('show');
            $("#savebtn").hide();
            $("#updbtn").show();
            $("#id_div").show();


            $("#eid").val(res.eid);
            $("#ename").val(res.ename);
            $("#email").val(res.email);
            $("#esalary").val(res.esalary);
            $("#ManagerId").val(res.managerId);
        },
        error: function () {
            alert('not');
        }
    });
}


$("#updbtn").click(function () {
    var obj = $("#empdets").serialize();

    $.ajax({
        url: '/EmployeeHandler/UpdateEmployees',
        type: 'Post',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        data: obj,
        success: function () {
            alert('Update Success');
            $("#exampleModal").modal('hide');
            FetchEmpDetails();
        },
        error: function () {
            alert('not');
        }
    });
});