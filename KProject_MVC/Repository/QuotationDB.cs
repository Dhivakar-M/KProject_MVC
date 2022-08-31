using KProject_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KProject_MVC.Repository
{
    public class QuotationDB
    {
        //declare connection string  
        private readonly string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
         
        public Quotation GetQuotation(int QuotationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                { 
                    con.Open();
                    SqlCommand com = new SqlCommand("Select_Quotation", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@QuotationId", QuotationId);
                    SqlDataReader rdr = com.ExecuteReader();
                    if (rdr.Read())
                    {
                        var objQuotation = new Quotation
                        {
                            QuotationId = Convert.ToInt32(rdr["QuotationId"]),
                            EnquiryDate = Convert.ToString(rdr["EnquiryDate"]),
                            EnquiryRefNumber = Convert.ToString(rdr["EnquiryRefNumber"]),
                            SupplierName = Convert.ToString(rdr["SupplierName"]),
                            AddressLine1 = Convert.ToString(rdr["AddressLine1"]),
                            AddressLine2 = Convert.ToString(rdr["AddressLine2"]),
                            Mobile = Convert.ToString(rdr["Mobile"]),
                            Phone = Convert.ToString(rdr["Phone"]),
                            Subject = Convert.ToString(rdr["Subject"]),
                            Description = Convert.ToString(rdr["Description"]),
                            PriceSummaryList = GetPriceSummaryList(QuotationId)
                        };
                        return objQuotation;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Quotation> ListAll()
        {
            var lstQuotation = new List<Quotation>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SelectAll_Quotation", con);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstQuotation.Add(new Quotation
                        {
                            QuotationId = Convert.ToInt32(rdr["QuotationId"]),
                            EnquiryDate = Convert.ToString(rdr["EnquiryDate"]),
                            EnquiryRefNumber = Convert.ToString(rdr["EnquiryRefNumber"]),
                            SupplierName = Convert.ToString(rdr["SupplierName"]),
                            AddressLine1 = Convert.ToString(rdr["AddressLine1"]),
                            AddressLine2 = Convert.ToString(rdr["AddressLine2"]),
                            Mobile = Convert.ToString(rdr["Mobile"]),
                            Phone = Convert.ToString(rdr["Phone"]),
                            Email = Convert.ToString(rdr["Email"]),
                            Subject = Convert.ToString(rdr["Subject"]),
                            Description = Convert.ToString(rdr["Description"])
                        });
                    }
                    return lstQuotation;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public int Add(Quotation objQuotation)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        var com = GetSqlCommand(con, emp, "Insert");
        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;
        //}

        //private SqlCommand GetSqlCommand(SqlConnection con, EmployeeMaster emp, string action)
        //{
        //    SqlCommand com = new SqlCommand("InsertUpdateEmployee", con)
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };
        //    com.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
        //    com.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
        //    com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
        //    com.Parameters.AddWithValue("@EmpSurName", emp.EmpSurName);
        //    com.Parameters.AddWithValue("@DOB", emp.DOB);

        //    com.Parameters.AddWithValue("@Nationality", emp.Nationality);
        //    com.Parameters.AddWithValue("@DOJ", emp.DOJ);
        //    com.Parameters.AddWithValue("@EmpContract", emp.EmpContract);
        //    com.Parameters.AddWithValue("@Designation", emp.Designation);
        //    com.Parameters.AddWithValue("@VisaStatus", emp.VisaStatus);

        //    com.Parameters.AddWithValue("@Department", emp.Department);
        //    com.Parameters.AddWithValue("@Insurance", emp.Insurance);

        //    com.Parameters.AddWithValue("@DrivingLicense", emp.DrivingLicense);
        //    com.Parameters.AddWithValue("@VaccinationStatus", emp.VaccinationStatus);
        //    com.Parameters.AddWithValue("@BasicSalary", emp.BasicSalary);
        //    com.Parameters.AddWithValue("@Allow1", emp.Allow1);
        //    com.Parameters.AddWithValue("@Allow2", emp.Allow2);

        //    com.Parameters.AddWithValue("@TotalAmount", emp.TotalAmount);
        //    com.Parameters.AddWithValue("@PassportNo", emp.PassportNo);
        //    com.Parameters.AddWithValue("@PassportExpiryDate", emp.PassportExpiryDate);
        //    com.Parameters.AddWithValue("@CivilIdNo", emp.CivilIdNo);
        //    com.Parameters.AddWithValue("@CivilIdExpiryDate", emp.CivilIdExpiryDate);

        //    com.Parameters.AddWithValue("@ResidenceNo", emp.ResidenceNo);
        //    com.Parameters.AddWithValue("@ResidenceExpiryDate", emp.ResidenceExpiryDate);
        //    com.Parameters.AddWithValue("@GatePassNo", emp.GatePassNo);
        //    com.Parameters.AddWithValue("@GatePassExpiryDate", emp.GatePassExpiryDate);
        //    com.Parameters.AddWithValue("@WorkPermitNo", emp.WorkPermitNo);

        //    com.Parameters.AddWithValue("@WorkPermitExpiryDate", emp.WorkPermitExpiryDate);
        //    com.Parameters.AddWithValue("@AccountNo", emp.AccountNo);
        //    com.Parameters.AddWithValue("@AccountDetails", emp.AccountDetails);
        //    com.Parameters.AddWithValue("@Leave", emp.Leave);
        //    com.Parameters.AddWithValue("@LeaveDetails", emp.LeaveDetails);
        //    com.Parameters.AddWithValue("@WorkLocation", emp.WorkLocation);
        //    com.Parameters.AddWithValue("@Action", action);
        //    return com;
        //}

        public List<PriceSummary> GetPriceSummaryList(int QuotationId)
        {
            List<PriceSummary> lst = new List<PriceSummary>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("Select_PriceSummary", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@QuotationId", QuotationId);
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new PriceSummary
                        {
                            PriceSummaryId = Convert.ToInt32(rdr["PriceSummaryId"]),
                            QuotationId = Convert.ToInt32(rdr["QuotationId"]),
                            Description = Convert.ToString(rdr["Description"]),
                            Quantity = Convert.ToInt32(rdr["Quantity"]),
                            Price = rdr["Price"] != DBNull.Value ? Convert.ToDecimal(rdr["Price"]) : 0,
                            Remarks = Convert.ToString(rdr["Remarks"])
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
    }
}