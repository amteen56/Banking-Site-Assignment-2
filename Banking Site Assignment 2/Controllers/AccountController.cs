using Banking_Site_Assignment_2.Models;
using Banking_Site_Assignment_2.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking_Site_Assignment_2.Controllers
{
    public class AccountController : Controller
    {
        private const string LOGIN_SQL =
           @"SELECT * FROM [User] 
            WHERE UserID = '{0}' 
              AND UserPw = '{1}'";
        private static string userid="{0}";
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Signin()
        {
            return View();
        }
        public ActionResult ViewInstallment()
        {
            List<Installment_Form> ds = DButil.GetList<Installment_Form>("SELECT * FROM [Installment]");
            return View(ds);
        }
        //
        public ActionResult CreateInstallment()
        {
            var ds = DButil.GetTable("SELECT * FROM [User] WHERE UserID = '{0}'", userid);
            Installment_Form ins = new Installment_Form();
            ins.FullName = ds.Rows[0]["FullName"].ToString();
            ins.DOB= ds.Rows[0]["DOB"].ToString();
            ins.ContactNo= ds.Rows[0]["ContactNo"].ToString();
            ins.Email= ds.Rows[0]["Email"].ToString();
            ins.age= ds.Rows[0]["age"].ToString();
            return View(ins);
        }
        [HttpPost]
        public ActionResult Login(UserSignIn model)
        {
            var a = AuthenticateUser(model.UserID, model.Password);
            if (a.Rows.Count < 1)
            {
                ViewData["Message"] = "Incorrect User ID or Password";
                ViewData["MsgType"] = "warning";
                return View("Signin");
            }
            else
            {
                if (TempData["returnUrl"] != null)
                {
                    string returnUrl = TempData["returnUrl"].ToString();
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                }
                return RedirectToAction("CreateInstallment");
            }
        }
             [HttpPost]
        public ActionResult CreaeIns(Installment_Form ins, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("CreateInstallment");
            }
            else
            {
                string insert =
                   @"INSERT INTO [Installment](FullName, Email,DOB,Age,ContactNo,Salary,Dependencies,PermonthInstallment,InerestRae,NoOfYear) VALUES
                 ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',{7},{8},{9})";
                if (DButil.ExecSQL(insert, ins.FullName, ins.Email, ins.DOB, ins.age, ins.ContactNo,ins.Salary,ins.Dependencies,ins.PermonthInstallment,ins.InerestRae,ins.NoOfYear) == 1)
                {
                    ViewData["Message"] = "Installment Successfully Registered";
                    ViewData["MsgType"] = "success";
                }
                else
                {
                    ViewData["Message"] = DButil.DB_Message;
                    ViewData["MsgType"] = "danger";
                }
                return View("CreateInstallment");
            }
        }
      
        public ActionResult Create(User usr,FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("UserRegister");
            }
            else
            {
                string insert =
                   @"INSERT INTO [User](UserID, UserPw, FullName, Email,DOB,Age,ContactNo) VALUES
                 ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
                if (DButil.ExecSQL(insert, usr.UserID, usr.UserPw, usr.FullName, usr.Email, usr.DOB,usr.age, usr.ContactNo) == 1)
                {
                    ViewData["Message"] = "User Successfully Registered";
                    ViewData["MsgType"] = "success";
                }
                else
                {
                    ViewData["Message"] = DButil.DB_Message;
                    ViewData["MsgType"] = "danger";
                }
                return View("Register");
            }
        }
        private DataTable AuthenticateUser(string uid, string pw)
        {
            DataTable ds = new DataTable();
                ds = DButil.GetTable(LOGIN_SQL, uid, pw);
            return ds;
        }
    }
}