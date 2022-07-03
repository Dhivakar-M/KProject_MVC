using KProject_MVC.Models;
using KProject_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}