//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
    //alert(" emp master document ready");
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/EmployeeMaster/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.EmployeeID + '</td>';
                html += '<td>' + item.EmployeeCode + '</td>';
                html += '<td>' + item.EmployeeName + '</td>';
                html += '<td>' + item.EmpSurName + '</td>';
                html += '<td>' + item.DOB + '</td>';
                //html += '<td>' + item.Nationality + '</td>';
                //html += '<td>' + item.DOJ + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.EmployeeID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.EmployeeID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {

    alert('Add invoked');
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),
        EmployeeCode: $('#EmployeeCode').val(),
        EmployeeName: $('#EmployeeName').val(),
        EmpSurName: $('#EmpSurName').val(),
        DOB: $('#DOB').val(),

        Nationality: $('#Nationality').val(),
        DOJ: $('#DOJ').val(),
        EmpContract: $('#EmpContract').val(),
        Designation: $('#Designation').val(),
        VisaStatus: $('#VisaStatus').val(),

        Department: $('#Department').val(), 
        Insurance: $('#Insurance').val(),


        DrivingLicense: $('#DrivingLicense').val(),
        VaccinationStatus: $('#VaccinationStatus').val(),
        BasicSalary: $('#BasicSalary').val(),
        Allow1: $('#Allow1').val(),
        Allow2: $('#Allow2').val(),

        TotalAmount: $('#TotalAmount').val(),
        PassportNo: $('#PassportNo').val(),
        PassportExpiryDate: $('#PassportExpiryDate').val(),
        CivilIdNo: $('#CivilIdNo').val(),
        CivilIdExpiryDate: $('#CivilIdExpiryDate').val(),

        ResidenceNo: $('#ResidenceNo').val(),
        ResidenceExpiryDate: $('#ResidenceExpiryDate').val(),
        GatePassNo: $('#GatePassNo').val(),
        GatePassExpiryDate: $('#GatePassExpiryDate').val(),
        WorkPermitNo: $('#WorkPermitNo').val(),

        WorkPermitExpiryDate: $('#WorkPermitExpiryDate').val(),
        AccountNo: $('#AccountNo').val(),
        AccountDetails: $('#AccountDetails').val(),
        Leave: $('#Leave').val(),
        LeaveDetails: $('#LeaveDetails').val(),
    };
    $.ajax({
        url: "/EmployeeMaster/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(EmpID) {
    $('#EmployeeCode').css('border-color', 'lightgrey');
    $('#EmployeeName').css('border-color', 'lightgrey');
    $('#EmpSurName').css('border-color', 'lightgrey');
    $('#DOB').css('border-color', 'lightgrey');

    $('#Nationality').css('border-color', 'lightgrey');
    $('#DOJ').css('border-color', 'lightgrey');
    $('#EmpContract').css('border-color', 'lightgrey');
    $('#Designation').css('border-color', 'lightgrey');
    $('#VisaStatus').css('border-color', 'lightgrey');

    $('#Department').css('border-color', 'lightgrey');
    $('#Insurance').css('border-color', 'lightgrey');

    $('#DrivingLicense').css('border-color', 'lightgrey');
    $('#VaccinationStatus').css('border-color', 'lightgrey');
    $('#BasicSalary').css('border-color', 'lightgrey');
    $('#Allow1').css('border-color', 'lightgrey');
    $('#Allow2').css('border-color', 'lightgrey');

    $('#TotalAmount').css('border-color', 'lightgrey');
    $('#PassportNo').css('border-color', 'lightgrey');
    $('#PassportExpiryDate').css('border-color', 'lightgrey');
    $('#CivilIdNo').css('border-color', 'lightgrey');
    $('#CivilIdExpiryDate').css('border-color', 'lightgrey');


    $('#ResidenceNo').css('border-color', 'lightgrey');
    $('#ResidenceExpiryDate').css('border-color', 'lightgrey');
    $('#GatePassNo').css('border-color', 'lightgrey');
    $('#GatePassExpiryDate').css('border-color', 'lightgrey');
    $('#WorkPermitNo').css('border-color', 'lightgrey');

    $('#WorkPermitExpiryDate').css('border-color', 'lightgrey');
    $('#AccountNo').css('border-color', 'lightgrey');
    $('#AccountDetails').css('border-color', 'lightgrey');
    $('#Leave').css('border-color', 'lightgrey');
    $('#LeaveDetails').css('border-color', 'lightgrey');


    $.ajax({
        url: "/EmployeeMaster/getbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#EmployeeID').val(result.EmployeeID);
            $('#EmployeeCode').val(result.EmployeeCode);
            $('#EmployeeName').val(result.EmployeeName);
            $('#EmpSurName').val(result.EmpSurName);
            $('#DOB').val(result.DOB);

            $('#Nationality').val(result.Nationality);
            $('#DOJ').val(result.DOJ);
            $('#EmpContract').val(result.EmpContract);
            $('#Designation').val(result.Designation);
            $('#VisaStatus').val(result.VisaStatus);


            $('#Department').val(result.Department);
            $('#Insurance').val(result.Insurance);

            $('#DrivingLicense').val(result.DrivingLicense);
            $('#VaccinationStatus').val(result.VaccinationStatus);
            $('#BasicSalary').val(result.BasicSalary);
            $('#Allow1').val(result.Allow1);
            $('#Allow2').val(result.Allow2);

            $('#TotalAmount').val(result.TotalAmount);
            $('#PassportNo').val(result.PassportNo);
            $('#PassportExpiryDate').val(result.PassportExpiryDate);
            $('#CivilIdNo').val(result.CivilIdNo);
            $('#CivilIdExpiryDate').val(result.CivilIdExpiryDate);

            $('#ResidenceNo').val(result.ResidenceNo);
            $('#ResidenceExpiryDate').val(result.ResidenceExpiryDate);
            $('#GatePassNo').val(result.GatePassNo);
            $('#GatePassExpiryDate').val(result.GatePassExpiryDate);
            $('#WorkPermitNo').val(result.WorkPermitNo);
  
            $('#WorkPermitExpiryDate').val(result.WorkPermitExpiryDate);
            $('#AccountNo').val(result.AccountNo);
            $('#AccountDetails').val(result.AccountDetails);
            $('#Leave').val(result.Leave);
            $('#LeaveDetails').val(result.LeaveDetails);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),
        EmployeeCode: $('#EmployeeCode').val(),
        EmployeeName: $('#EmployeeName').val(),
        EmpSurName: $('#EmpSurName').val(),
        DOB: $('#DOB').val(),

        Nationality: $('#Nationality').val(),
        DOJ: $('#DOJ').val(),
        EmpContract: $('#EmpContract').val(),
        Designation: $('#Designation').val(),
        VisaStatus: $('#VisaStatus').val(),

        Department: $('#Department').val(),
        Insurance: $('#Insurance').val(),

        DrivingLicense: $('#DrivingLicense').val(),
        VaccinationStatus: $('#VaccinationStatus').val(),
        BasicSalary: $('#BasicSalary').val(),
        Allow1: $('#Allow1').val(),
        Allow2: $('#Allow2').val(),

        TotalAmount: $('#TotalAmount').val(),
        PassportNo: $('#PassportNo').val(),
        PassportExpiryDate: $('#PassportExpiryDate').val(),
        CivilIdNo: $('#CivilIdNo').val(),
        CivilIdExpiryDate: $('#CivilIdExpiryDate').val(),

        ResidenceNo: $('#ResidenceNo').val(),
        ResidenceExpiryDate: $('#ResidenceExpiryDate').val(),
        GatePassNo: $('#GatePassNo').val(),
        GatePassExpiryDate: $('#GatePassExpiryDate').val(),
        WorkPermitNo: $('#WorkPermitNo').val(),

        WorkPermitExpiryDate: $('#WorkPermitExpiryDate').val(),
        AccountNo: $('#AccountNo').val(),
        AccountDetails: $('#AccountDetails').val(),
        Leave: $('#Leave').val(),
        LeaveDetails: $('#LeaveDetails').val(),
  

    };
    $.ajax({
        url: "/EmployeeMaster/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');

            $('#EmployeeID').val("");
            $('#EmployeeCode').val("");
            $('#EmployeeName').val("");
            $('#EmpSurName').val("");
            $('#DOB').val();

            $('#Nationality').val("");
            $('#DOJ').val("");
            $('#EmpContract').val("");
            $('#Designation').val("");
            $('#VisaStatus').val("");


            $('#Department').val("");
            $('#Insurance').val("");

            $('#DrivingLicense').val("");
            $('#VaccinationStatus').val("");
            $('#BasicSalary').val("");
            $('#Allow1').val("");
            $('#Allow2').val("");

            $('#TotalAmount').val("");
            $('#PassportNo').val("");
            $('#PassportExpiryDate').val("");
            $('#CivilIdNo').val("");
            $('#CivilIdExpiryDate').val("");

            $('#ResidenceNo').val("");
            $('#ResidenceExpiryDate').val("");
            $('#GatePassNo').val("");
            $('#GatePassExpiryDate').val("");
            $('#WorkPermitNo').val();

            $('#WorkPermitExpiryDate').val("");
            $('#AccountNo').val("");
            $('#AccountDetails').val("");
            $('#Leave').val("");
            $('#LeaveDetails').val("");
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/EmployeeMaster/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#EmployeeCode').val("");
    $('#EmployeeName').val("");
    $('#EmpSurName').val("");
    $('#DOB').val("");

    $('#Nationality').val("");
    $('#DOJ').val("");
    $('#EmpContract').val("");
    $('#Designation').val("");
    $('#VisaStatus').val("");


    $('#Department').val("");
    $('#Insurance').val("");

    $('#DrivingLicense').val("");
    $('#VaccinationStatus').val("");
    $('#BasicSalary').val("");
    $('#Allow1').val("");
    $('#Allow2').val("");

    $('#TotalAmount').val("");
    $('#PassportNo').val("");
    $('#PassportExpiryDate').val("");
    $('#CivilIdNo').val("");
    $('#CivilIdExpiryDate').val("");

    $('#ResidenceNo').val("");
    $('#ResidenceExpiryDate').val("");
    $('#GatePassNo').val("");
    $('#GatePassExpiryDate').val("");
    $('#WorkPermitNo').val();

    $('#WorkPermitExpiryDate').val("");
    $('#AccountNo').val("");
    $('#AccountDetails').val("");
    $('#Leave').val("");
    $('#LeaveDetails').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#EmployeeCode').css('border-color', 'lightgrey');
    $('#EmployeeName').css('border-color', 'lightgrey');
    $('#EmpSurName').css('border-color', 'lightgrey');
    $('#DOB').css('border-color', 'lightgrey');

    $('#Nationality').css('border-color', 'lightgrey');
    $('#DOJ').css('border-color', 'lightgrey');
    $('#EmpContract').css('border-color', 'lightgrey');
    $('#Designation').css('border-color', 'lightgrey');
    $('#VisaStatus').css('border-color', 'lightgrey');

    $('#Department').css('border-color', 'lightgrey');
    $('#Insurance').css('border-color', 'lightgrey');

    $('#DrivingLicense').css('border-color', 'lightgrey');
    $('#VaccinationStatus').css('border-color', 'lightgrey');
    $('#BasicSalary').css('border-color', 'lightgrey');
    $('#Allow1').css('border-color', 'lightgrey');
    $('#Allow2').css('border-color', 'lightgrey');

    $('#TotalAmount').css('border-color', 'lightgrey');
    $('#PassportNo').css('border-color', 'lightgrey');
    $('#PassportExpiryDate').css('border-color', 'lightgrey');
    $('#CivilIdNo').css('border-color', 'lightgrey');
    $('#CivilIdExpiryDate').css('border-color', 'lightgrey');


    $('#ResidenceNo').css('border-color', 'lightgrey');
    $('#ResidenceExpiryDate').css('border-color', 'lightgrey');
    $('#GatePassNo').css('border-color', 'lightgrey');
    $('#GatePassExpiryDate').css('border-color', 'lightgrey');
    $('#WorkPermitNo').css('border-color', 'lightgrey');

    $('#WorkPermitExpiryDate').css('border-color', 'lightgrey');
    $('#AccountNo').css('border-color', 'lightgrey');
    $('#AccountDetails').css('border-color', 'lightgrey');
    $('#Leave').css('border-color', 'lightgrey');
    $('#LeaveDetails').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#EmployeeCode').val().trim() == "") {
        $('#EmployeeCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#EmployeeCode').css('border-color', 'lightgrey');
    }
    if ($('#EmployeeName').val().trim() == "") {
        $('#EmployeeName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#EmployeeName').css('border-color', 'lightgrey');
    }
    if ($('#EmpSurName').val().trim() == "") {
        $('#EmpSurName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#EmpSurName').css('border-color', 'lightgrey');
    }
    if ($('#DOB').val().trim() == "") {
        $('#DOB').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DOB').css('border-color', 'lightgrey');
    }
    return isValid;
}  