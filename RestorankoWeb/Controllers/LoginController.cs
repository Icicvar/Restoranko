using RestorankoWeb.Dao;
using RestorankoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RestorankoWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repository repository;

        public LoginController()
        {
            repository = new Repository();
        }

        

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = await repository.Register(user);

                if (isAuthenticated)
                {
                    return RedirectToAction("Welcome", "Home", user);
                }
                else
                {                    
                    ModelState.AddModelError(string.Empty, "Neispravno korisničko ime ili lozinka");
                }
            }

            // Prikaz forme za prijavu s greškama
            return View(user);
        }

        

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            if (ModelState.IsValidField("email") && ModelState.IsValidField("password"))
            {
                User isAuthenticated = await repository.Login(user);

                if (isAuthenticated != null)
                {
                    // Prijavljivanje uspješno
                    
                    Session["Email"] = user.Email.ToString();
                    return RedirectToAction("Welcome", "Home", isAuthenticated); 
                }
                else
                {
                    // Prijavljivanje nije uspjelo
                    ModelState.AddModelError(string.Empty, "Neispravno korisničko ime ili lozinka");
                }
            }
            
            // Prikaz forme za prijavu s greškama
            return View(user);
        }
        //[HttpPost]
        //public ActionResult Login(User user, Repository sqlRepository)
        //{
        //    sqlRepository.Login(user);

        //    if (sqlRepository.Login(user))
        //    {
        //        Session["Email"] = user.Email.ToString();
        //        return RedirectToAction("Welcome");
        //    }
        //    else
        //    {
        //        ViewData["Message"] = "User Login Details Failed!!";
        //    }
        //    if (user.Email.ToString() != null)
        //    {
        //        Session["Email"] = user.Email.ToString();
        //        status = "1";
        //    }
        //    else
        //    {
        //        status = "3";
        //    }


        //    m = user;
        //    return View();
        //}


            //String SqlCon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            //SqlConnection con = new SqlConnection(SqlCon);
            //string SqlQuery = "select Email,Password from \"User\" where Email=@Email and Password=@Password";
            //con.Open();
            //SqlCommand cmd = new SqlCommand(SqlQuery, con); ;
            //cmd.Parameters.AddWithValue("@Email", user.Email);
            //cmd.Parameters.AddWithValue("@Password", user.Password);
            //SqlDataReader sdr = cmd.ExecuteReader();
            //if (sdr.Read())
            //{
            //    Session["Email"] = user.Email.ToString();
            //    return RedirectToAction("Welcome");
            //}
            //else
            //{
            //    ViewData["Message"] = "User Login Details Failed!!";
            //}
            //if (user.Email.ToString() != null)
            //{
            //    Session["Email"] = user.Email.ToString();
            //    status = "1";
            //}
            //else
            //{
            //    status = "3";
            //}

            //con.Close();
            //m=user;
            //return View();
            ////return new JsonResult { Data = new { status = status } };  
        //}

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }

       

        
    }
}