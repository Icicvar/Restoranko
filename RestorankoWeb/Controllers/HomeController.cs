using RestorankoWeb.Dao;
using RestorankoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RestorankoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository repository;

        public HomeController()
        {
            repository = new Repository();
        }

        //public string value = "";

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (Request.HttpMethod == "POST")
            {
                User er = new User();

                repository.CreateUser(user);
            }
            
                return RedirectToAction("Welcome");
            
            
        }
        // GET: /UserLogin/  
        public string status;
        User m;

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            if (ModelState.IsValidField("email") && ModelState.IsValidField("password"))
            {
                bool isAuthenticated = await repository.Login(user);

                if (isAuthenticated)
                {
                    // Prijavljivanje uspješno
                    m = user;
                    return RedirectToAction("Welcome"); // Preusmjerite na odgovarajuću akciju i kontroler
                }
                else
                {
                    // Prijavljivanje nije uspjelo
                    ModelState.AddModelError(string.Empty, "Neispravno korisničko ime ili lozinka");
                }
            }
            m = user;
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

        [HttpGet]
        public ActionResult Welcome()
        {
           
            return View(m);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

       

        
    }
}