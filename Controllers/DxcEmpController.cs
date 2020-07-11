using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeMvcAssaignment.Controllers
{
    public class DxcEmpController : Controller
    {
        // GET: DxcEmp
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string s1 = frm[0].ToString();
            string s2 = frm[1].ToString();
            string s3 = frm[2].ToString();
            DxcdbEntities db = new DxcdbEntities();
            dxcempp u = db.dxcempps.FirstOrDefault(x => x.username == s1 & x.password == s2 & x.role == s3);
            if (u == null)
                return Redirect("/HomePage.aspx");


            else if (u.role == "Admin")
                return RedirectToAction("AdminHome");
            else
                return RedirectToAction("CustomerHome");



        }


        public ActionResult AdminHome()
        {
            DxcdbEntities db = new DxcdbEntities();
            var res = db.dxcempps.ToList();
            return View(res);
        }
        public ActionResult CustomerHome()
        {
            return View();
        }
    }
}