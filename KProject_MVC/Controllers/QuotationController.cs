using KProject_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KProject_MVC.Controllers
{
    public class QuotationController : Controller
    {
        private readonly QuotationDB objQuotationDB =new QuotationDB();
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(objQuotationDB.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Search(int QuotationId)
        {
            var Quotation = objQuotationDB.GetQuotation(QuotationId);
            return Json(Quotation, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult AddEditQuotation(int? quotationId)
        {
            return View();
        }

        //public JsonResult Add(Quotation quotation)
        //{
        //    return Json(objQuotationDB.Add(quotation), JsonRequestBehavior.AllowGet);
        //}
    }
}