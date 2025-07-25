$(document).ready(function () {
    FetchEmp();
});

$("#modalbtn").click(function () {
    $("#exampleModal").modal('show');
});

$("#savebtn").click(function () {
    var obj = $("#submitform").serialize();


    console.log(obj);
    $.ajax({
        url: '/Ajax/AddEmployee',
        method: 'Post',
        dataType: 'json',
        data: obj,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        success: function(){
            alert('Emp Added Succes');
            $("#exampleModal").modal('hide');
            FetchEmp();
        },
        error: function () {
            alert('not loaded');
        }
    });
});

function FetchEmp()
{
    $.ajax({
        url: '/Ajax/FetchEmployeeData',
        dataType: 'json',
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            var obj = '';
            $.each(response, function (index, item) {
                obj += '<tr>';
                obj += `<td>${item.eid}</td>`;
                obj += `<td>${item.ename}</td>`;
                obj += `<td>${item.email}</td>`;
                obj += `<td>${item.esalary}</td>`;
                obj += '<td><a class="btn btn-sm btn-danger" onclick="DeleteEmp('+item.eid+')">Delete</a></td>';
                obj +='</tr>';
            });

            $("#mydata").html(obj);
        },
        error: function () {

        }
    });
}

function DeleteEmp(id) {
    if (confirm('Are you Sure?')) {
        $.ajax({
            url: '/Ajax/DelEmp?empid=' + id,
            dataType: 'json',
            success: function () {
                alert('Emp Deleted Success');
                FetchEmp();
            },
            error: function () {
                alert('not loading');
            }
        });
    }
    else {
        alert('Not an Issues');
    }
 
}

$("#txt").keyup(function () {
    var data = $("#txt").val();
    $.ajax({
        url: '/Ajax/SearchEmployeeData?mydata='+data,
        dataType: 'json',
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            var obj = '';
            $.each(response, function (index, item) {
                obj += '<tr>';
                obj += `<td>${item.eid}</td>`;
                obj += `<td>${item.ename}</td>`;
                obj += `<td>${item.email}</td>`;
                obj += `<td>${item.esalary}</td>`;
                obj += '<td><a class="btn btn-sm btn-danger" onclick="DeleteEmp(' + item.eid + ')">Delete</a></td>';
                obj += '</tr>';
            });

            $("#mydata").html(obj);
        },
        error: function () {

        }
    });

});