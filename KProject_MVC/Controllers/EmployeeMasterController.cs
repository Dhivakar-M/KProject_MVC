using KProject_MVC.Models;
using KProject_MVC.Repository;
using System;
using System.Collections.Generic;
using KProject_MVC.Report;
using System.Web.Mvc;

namespace KProject_MVC.Controllers
{
    public class EmployeeMasterController : Controller
    {
        EmployeeMasterDB empDB = new EmployeeMasterDB();
        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
            //return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(EmployeeMaster emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(EmployeeMaster emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuotationReport()
        {
            var quotationReportModel = new QuotationReportModel
            {
                FromCompanyName = "Spetco International Petroleum",
                FromEmail = "spetco@gmail.com",
                FromDate = Convert.ToDateTime("03.04.2022"),
                ToCompanyName = "Spetco International Petroleum",
                ToEmail = "sales@uogei.com",
                ToDate = Convert.ToDateTime("04.04.2022"),
                PriceSummaryList = GetPriceSummary()
            };
            PDFReport objPDFReport=new PDFReport();
            byte[] quotationBytes = objPDFReport.PrepareQuotatioReport(quotationReportModel);
            return File(quotationBytes,"application/pdf");
        }

        private List<PriceSummary1> GetPriceSummary()
        {
            var lstPriceSummary = new List<PriceSummary1>();
            var summary = new PriceSummary1
            {
                SerialNo = 1,
                Description = "Civil works of Crash Barriers",
                Quantity = 500,
                LumpSum = 700000,
                Remarks = "Civil"
            };
            lstPriceSummary.Add(summary);
            var summary1 = new PriceSummary1
            {
                SerialNo = 2,
                Description = "Eleactrical works",
                Quantity = 200,
                LumpSum = 500000,
                Remarks = "Eleactrical"
            };
            lstPriceSummary.Add(summary1);

            return lstPriceSummary;
        }
    }
}