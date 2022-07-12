using KProject_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KProject_MVC.Repository
{
    public class EmployeeMasterDB
    {
        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        string EmpImageBase = ConfigurationManager.AppSettings["EmployeeImageBasePath"];
        //Return list of all Employees  
        public List<EmployeeMaster> ListAll()
        {
            List<EmployeeMaster> lst = new List<EmployeeMaster>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SelectEmployee", con);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new EmployeeMaster
                        {
                            EmployeeID = Convert.ToInt32(rdr["EmployeeId"]),
                            EmployeeCode = Convert.ToString(rdr["EmployeeCode"]),
                            EmployeeName = Convert.ToString(rdr["EmployeeName"]),
                            EmpSurName = Convert.ToString(rdr["EmpSurName"]),
                            DOB = Convert.ToString(rdr["DOB"]),
                            WorkLocation = Convert.ToString(rdr["WorkLocation"]),
                            EmployeeImgPath = GetEmployeePath(Convert.ToString(rdr["EmployeeCode"])),
                            Nationality = Convert.ToString(rdr["Nationality"]),
                            DOJ = Convert.ToString(rdr["DOJ"]),
                            EmpContract = Convert.ToString(rdr["EmpContract"]),
                            Designation = Convert.ToString(rdr["Designation"]),
                            VisaStatus = Convert.ToString(rdr["VisaStatus"]),

                            Department = Convert.ToString(rdr["Department"]),
                            Insurance = Convert.ToString(rdr["Insurance"]),

                            DrivingLicense = Convert.ToString(rdr["DrivingLicense"]),
                            VaccinationStatus = Convert.ToString(rdr["VaccinationStatus"]),
                            BasicSalary = rdr["BasicSalary"] != DBNull.Value ? Convert.ToDecimal(rdr["BasicSalary"]) : 0,
                            Allow1 = rdr["Allow1"] != DBNull.Value ? Convert.ToDecimal(rdr["Allow1"]) : 0,
                            Allow2 = rdr["Allow2"] != DBNull.Value ? Convert.ToDecimal(rdr["Allow2"]) : 0,
                            TotalAmount = rdr["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(rdr["Allow2"]) : 0,
                            PassportNo = Convert.ToString(rdr["PassportNo"]),
                            PassportExpiryDate = Convert.ToString(rdr["PassportExpiryDate"]),
                            CivilIdNo = Convert.ToString(rdr["CivilIdNo"]),
                            CivilIdExpiryDate = Convert.ToString(rdr["CivilIdExpiryDate"]),

                            ResidenceNo = Convert.ToString(rdr["ResidenceNo"]),
                            ResidenceExpiryDate = Convert.ToString(rdr["ResidenceExpiryDate"]),
                            GatePassNo = Convert.ToString(rdr["GatePassNo"]),
                            GatePassExpiryDate = Convert.ToString(rdr["GatePassExpiryDate"]),
                            WorkPermitNo = Convert.ToString(rdr["WorkPermitNo"]),

                            WorkPermitExpiryDate = Convert.ToString(rdr["WorkPermitExpiryDate"]),
                            AccountNo = Convert.ToString(rdr["AccountNo"]),
                            AccountDetails = Convert.ToString(rdr["AccountDetails"]),
                            Leave = Convert.ToString(rdr["Leave"]),
                            LeaveDetails = Convert.ToString(rdr["LeaveDetails"])
                        });
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method for Adding an Employee  
        public int Add(EmployeeMaster emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                //SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                //com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                //com.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                //com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                //com.Parameters.AddWithValue("@EmpSurName", emp.EmpSurName);
                //com.Parameters.AddWithValue("@DOB", emp.DOB);

                //com.Parameters.AddWithValue("@Nationality", emp.Nationality);
                //com.Parameters.AddWithValue("@DOJ", emp.DOJ);
                //com.Parameters.AddWithValue("@EmpContract", emp.EmpContract);
                //com.Parameters.AddWithValue("@Designation", emp.Designation);
                //com.Parameters.AddWithValue("@VisaStatus", emp.VisaStatus);

                //com.Parameters.AddWithValue("@Department", emp.Department);
                //com.Parameters.AddWithValue("@Insurance", emp.Insurance);

                //com.Parameters.AddWithValue("@DrivingLicense", emp.DrivingLicense);
                //com.Parameters.AddWithValue("@VaccinationStatus", emp.VaccinationStatus);
                //com.Parameters.AddWithValue("@BasicSalary", emp.BasicSalary);
                //com.Parameters.AddWithValue("@Allow1", emp.Allow1);
                //com.Parameters.AddWithValue("@Allow2", emp.Allow2);

                //com.Parameters.AddWithValue("@TotalAmount", emp.TotalAmount);
                //com.Parameters.AddWithValue("@PassportNo", emp.PassportNo);
                //com.Parameters.AddWithValue("@PassportExpiryDate", emp.PassportExpiryDate);
                //com.Parameters.AddWithValue("@CivilIdNo", emp.CivilIdNo);
                //com.Parameters.AddWithValue("@CivilIdExpiryDate", emp.CivilIdExpiryDate);

                //com.Parameters.AddWithValue("@ResidenceNo", emp.ResidenceNo);
                //com.Parameters.AddWithValue("@ResidenceExpiryDate", emp.ResidenceExpiryDate);
                //com.Parameters.AddWithValue("@GatePassNo", emp.GatePassNo);
                //com.Parameters.AddWithValue("@GatePassExpiryDate", emp.GatePassExpiryDate);
                //com.Parameters.AddWithValue("@WorkPermitNo", emp.WorkPermitNo);

                //com.Parameters.AddWithValue("@WorkPermitExpiryDate", emp.WorkPermitExpiryDate);
                //com.Parameters.AddWithValue("@AccountNo", emp.AccountNo);
                //com.Parameters.AddWithValue("@AccountDetails", emp.AccountDetails);
                //com.Parameters.AddWithValue("@Leave", emp.Leave);
                //com.Parameters.AddWithValue("@LeaveDetails", emp.LeaveDetails);
                //com.Parameters.AddWithValue("@WorkLocation", emp.LeaveDetails);
                //com.Parameters.AddWithValue("@Action", "Insert");
                var com = GetSqlCommand(con, emp, "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Employee record  
        public int Update(EmployeeMaster emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                //SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                //com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                //com.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                //com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                //com.Parameters.AddWithValue("@EmpSurName", emp.EmpSurName);
                //com.Parameters.AddWithValue("@DOB", emp.DOB);
                var com = GetSqlCommand(con, emp, "Update");



                //com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an EmployeeMaster  
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployeeID", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        private string GetEmployeePath(string code)
        {
            string retValue = EmpImageBase + code + "/" + "photo.jpg";
            return retValue;
        }

        private SqlCommand GetSqlCommand(SqlConnection con, EmployeeMaster emp, string action)
        {
            SqlCommand com = new SqlCommand("InsertUpdateEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            com.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
            com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
            com.Parameters.AddWithValue("@EmpSurName", emp.EmpSurName);
            com.Parameters.AddWithValue("@DOB", emp.DOB);

            com.Parameters.AddWithValue("@Nationality", emp.Nationality);
            com.Parameters.AddWithValue("@DOJ", emp.DOJ);
            com.Parameters.AddWithValue("@EmpContract", emp.EmpContract);
            com.Parameters.AddWithValue("@Designation", emp.Designation);
            com.Parameters.AddWithValue("@VisaStatus", emp.VisaStatus);

            com.Parameters.AddWithValue("@Department", emp.Department);
            com.Parameters.AddWithValue("@Insurance", emp.Insurance);

            com.Parameters.AddWithValue("@DrivingLicense", emp.DrivingLicense);
            com.Parameters.AddWithValue("@VaccinationStatus", emp.VaccinationStatus);
            com.Parameters.AddWithValue("@BasicSalary", emp.BasicSalary);
            com.Parameters.AddWithValue("@Allow1", emp.Allow1);
            com.Parameters.AddWithValue("@Allow2", emp.Allow2);

            com.Parameters.AddWithValue("@TotalAmount", emp.TotalAmount);
            com.Parameters.AddWithValue("@PassportNo", emp.PassportNo);
            com.Parameters.AddWithValue("@PassportExpiryDate", emp.PassportExpiryDate);
            com.Parameters.AddWithValue("@CivilIdNo", emp.CivilIdNo);
            com.Parameters.AddWithValue("@CivilIdExpiryDate", emp.CivilIdExpiryDate);

            com.Parameters.AddWithValue("@ResidenceNo", emp.ResidenceNo);
            com.Parameters.AddWithValue("@ResidenceExpiryDate", emp.ResidenceExpiryDate);
            com.Parameters.AddWithValue("@GatePassNo", emp.GatePassNo);
            com.Parameters.AddWithValue("@GatePassExpiryDate", emp.GatePassExpiryDate);
            com.Parameters.AddWithValue("@WorkPermitNo", emp.WorkPermitNo);

            com.Parameters.AddWithValue("@WorkPermitExpiryDate", emp.WorkPermitExpiryDate);
            com.Parameters.AddWithValue("@AccountNo", emp.AccountNo);
            com.Parameters.AddWithValue("@AccountDetails", emp.AccountDetails);
            com.Parameters.AddWithValue("@Leave", emp.Leave);
            com.Parameters.AddWithValue("@LeaveDetails", emp.LeaveDetails);
            com.Parameters.AddWithValue("@WorkLocation", emp.WorkLocation);
            com.Parameters.AddWithValue("@Action", action);
            return com;
        }
    }
}