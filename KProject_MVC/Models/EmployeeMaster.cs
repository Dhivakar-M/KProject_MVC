using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KProject_MVC.Models
{
    public class EmployeeMaster
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmpSurName { get; set; }
        public string DOB { get; set; }
        public string Nationality { get; set; }
        public string DOJ { get; set; }
        public string EmpContract { get; set; }
        public string Designation { get; set; }
        public string VisaStatus { get; set; }
        public string Department { get; set; }
        public string Insurance { get; set; }
        public string DrivingLicense { get; set; }
        public string VaccinationStatus { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? Allow1 { get; set; }
        public decimal? Allow2 { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PassportNo { get; set; }
        public string PassportExpiryDate { get; set; }
        public string CivilIdNo { get; set; }
        public string CivilIdExpiryDate { get; set; }
        public string ResidenceNo { get; set; }
        public string ResidenceExpiryDate { get; set; }
        public string GatePassNo { get; set; }
        public string GatePassExpiryDate { get; set; }
        public string WorkPermitNo { get; set; }
        public string WorkPermitExpiryDate { get; set; }
        public string AccountNo { get; set; }
        public string AccountDetails { get; set; }
        public string Leave { get; set; }
        public string LeaveDetails { get; set; }
        public string EmployeeImgPath { get; set; }
        public string WorkLocation { get; set; }



    }
}