//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Add Data Function   
function Add() {

    alert('Add method invoked');

    var quotationObj = {
        EnquiryDate: $('#enqDate').val(),
        EnquiryRefNumber: $('#enqRefNo').val(),
        SupplierName: $('#txtSupplierName').val(),
        AddressLine1: $('#txtAddressline1').val(),
        AddressLine2: $('#txtAddressline2').val(),
        Email: $('#txtEmail').val(),
        Mobile: $('#txtMobile').val(),
        Phone: $('#txtPhone').val(),
        Subject: $('#txtSubject').val(),
        Description: $('#txtDescription').val()
    };
    $.ajax({
        url: "/Quotation/Add",
        data: JSON.stringify(quotationObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            navigateToQuotationList();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
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
        WorkLocation: $('#location').val(),
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

function navigateToQuotationList() {
    window.location.href = '/Quotation/Index';
}
