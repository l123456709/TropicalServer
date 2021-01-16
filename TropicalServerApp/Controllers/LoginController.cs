using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TropicalServerApp.Controllers
{
    public class LoginController : Controller
    {
        // static user object 
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //define this action as a post action
        [HttpPost]
        //action for post URL
        public ActionResult Authorize(TropicalServerApp.Models.tblTropicalUser tblTropicalUser)
        {
            using (Models.TropicalServerEntities2 db = new Models.TropicalServerEntities2()) 
            {
                //FirstOrDefault(): Returns the first element of a sequence, or a default value if no element is found.
                var userDetails = db.tblTropicalUsers.Where(x => x.LoginID == tblTropicalUser.LoginID && x.Password == tblTropicalUser.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    tblTropicalUser.LoginErrorMessage = "Wrong username or password.";
                    return View("Login", tblTropicalUser);
                }
                else 
                {
                    Session["LoginID"] = userDetails.LoginID;
                    //redirect users to the appropriate landing page
                    return RedirectToAction("Orders", "Product");
                }
            }
        }

        public ActionResult ForgotUsername()
        {
            return View("Email");
        }

        public ActionResult ForgotPassword()
        {
            return View("Email");
        }

        public ActionResult AuthorizeEmail(TropicalServerApp.Models.tblTropicalUser tblTropicalUser)
        {
            using (Models.TropicalServerEntities2 db = new Models.TropicalServerEntities2())
            {
                var userEmail = db.tblTropicalUsers.Where(x => x.Email == tblTropicalUser.Email).FirstOrDefault();
                if (userEmail == null)
                {
                    return View("Email", tblTropicalUser);
                }
                else
                {
                    Session["Email"] = userEmail.Email;
                    //redirect users to the reset username or password page
                    return RedirectToAction("Reset", "Login");
                }
            }
        }

        public ActionResult Reset()
        {
            return View();
        }

    }
}