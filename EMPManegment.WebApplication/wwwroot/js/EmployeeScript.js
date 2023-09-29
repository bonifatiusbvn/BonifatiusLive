
$(document).ready(function () {
    
    GetDepartment();
    GetCountry();
    GetQuestion();
    $('#ddlCountry').change(function () {
        var Text = $("#ddlCountry Option:Selected").text();
        var id = $(this).val();
        
        $("#txtcountry").val(Text);
        $('#ddlState').empty();
        $('#ddlState').append('<Option >--Select State--</Option>');
        $.ajax({
            url: '/EmpAddDetails/GetState?id=' + id,
            success: function (result) {
                
                $.each(result, function (i, data) {
                    $('#ddlState').append('<Option value=' + data.id + '>' + data.stateName + '</Option>')
                });
            }
        });
    });


    $('#ddlState').change(function () {
        var Text = $("#ddlState Option:Selected").text();
        var id = $(this).val();
        $("#txtstate").val(Text);
        $('#ddlCity').empty();
        $('#ddlCity').append('<Option >--Select City--</Option>');
        $.ajax({
            url: '/EmpAddDetails/GetCity?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#ddlCity').append('<Option value=' + data.id + '>' + data.cityName + '</Option>');

                });
            }
        });
    });

});


function GetCountry() {
    
    $.ajax({
        url: '/EmpAddDetails/GetCountrys',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#ddlCountry').append('<Option value=' + data.id + '>' + data.countryName + '</Option>')

            });
        }
    });
}

function Citytext(sel) {
    $("#txtcity").val((sel.options[sel.selectedIndex].text));
}


function Departmenttext(sel) {
    
    $("#txtdeptid").val((sel.options[sel.selectedIndex].text));
}


function Questiontext(sel) {
    $("#txtquestionid").val((sel.options[sel.selectedIndex].text));
}
function GetDepartment() {
    
    $.ajax({
        url: '/EmpAddDetails/GetDepartment',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#ddlDepartmenrnt').append('<Option value=' + data.id + '>' + data.departments + '</Option>')

            });
        }
    });
}

function GetQuestion() {

    $.ajax({
        url: '/EmpAddDetails/GetQuestion',
        success: function (result) {
            
            $.each(result, function (i, data) {
                $('#ddlQuestion').append('<Option value=' + data.id + '>' + data.questions + '</Option>')

            });
        }
    });
}