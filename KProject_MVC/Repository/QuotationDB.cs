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

        public int Add(Quotation objQuotation)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                var com = GetSqlCommand(con, objQuotation, "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        private SqlCommand GetSqlCommand(SqlConnection con, Quotation objQuotation, string action)
        {
            SqlCommand com = new SqlCommand("InsertUpdateQuotation", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@QuotationId", objQuotation.QuotationId);
            com.Parameters.AddWithValue("@EnquiryDate", objQuotation.EnquiryDate);
            com.Parameters.AddWithValue("@EnquiryRefNumber", objQuotation.EnquiryRefNumber);
            com.Parameters.AddWithValue("@SupplierName", objQuotation.SupplierName);
            com.Parameters.AddWithValue("@AddressLine1", objQuotation.AddressLine1);
            com.Parameters.AddWithValue("@AddressLine2", objQuotation.AddressLine2);
            com.Parameters.AddWithValue("@Email", objQuotation.Email);
            com.Parameters.AddWithValue("@Mobile", objQuotation.Mobile);
            com.Parameters.AddWithValue("@Phone", objQuotation.Phone);
            com.Parameters.AddWithValue("@Subject", objQuotation.Subject);
            com.Parameters.AddWithValue("@Description", objQuotation.Description);
            com.Parameters.AddWithValue("@Action", action);
            return com;
        }

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