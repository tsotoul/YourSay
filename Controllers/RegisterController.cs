using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourSay.Models;

namespace YourSay.Controllers
{
    public class RegisterController : Controller
    {
        // For use by the developer only
        public ActionResult Index()
        {
            using (YourSayDB db = new YourSayDB())
            {
                return View(db.userAccount.ToList());                                                           //return the Causes BdSet to the View
            }
        }

        public ActionResult Register()
        {
            return View();                                                                                      //Return the Model to the view
        }


        //Post method to add the inserted account details to the DbSet
        [HttpPost]
        public ActionResult Register(UserAccount account, bool AcceptTerms)                                     //Get the account details and the accept terms from the form
        {
            if (ModelState.IsValid && AcceptTerms == true)                                                      //Check in the backend if the form is valid
            {
                using(YourSayDB db = new YourSayDB())
                {
                    db.userAccount.Add(account);                                                                //Add the inserted account details to the DbSet
                    db.SaveChanges();                                                                           //Save changes
                }
                ModelState.Clear();                                                                             //Clear the form
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered";      //Pass the message to the viewer
            }
            return View();                                                                                      //return the view
        }

        //Method to login to the website 
        public ActionResult Login()
        {
            if(Session["UserID"] == null)                                                                       //Check if the user is already logged in
            {
                return View();                                                                                  //return the view
            }
            else
            {
                Session["UserID"] = null;                                                                       //If the user is not logged,
                return RedirectToAction("LoggedOut");                                                           //Redirect to LoggedOut
            }
        }

        //Post method to get the login details and log in the user
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (YourSayDB db = new YourSayDB())
            {
                var usr = db.userAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);//Check if the username and password match the DbSet
                if (usr != null)    
                {
                    Session["UserID"] = usr.UserId.ToString();                                                   //Crete the session ID
                    Session["Username"] = usr.UserName.ToString();                                               //Create hte session Username
                    return RedirectToAction("LoggedIn");                                                         //Redirect to LoggedIn
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong");                               //Send error message to the view
                }
            }
            return View();                                                                                      //return the view
        }

        //Method to return the LoggedIn page if user logs in
        public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)                                                                       //If the user logs in
            {
                return View();                                                                                  //Return the LoggedIn view
            }
            else
            {
                return RedirectToAction("Login");                                                               //If user is not logged in, return the LoggedOut view
            }
        }

        //Method to return the LoggedIn page if user logs out
        public ActionResult LoggedOut()
        {
            return View();                                                                                      //Return the LoggedOut view
        }


    }
}