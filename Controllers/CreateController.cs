using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourSay.Models;

namespace YourSay.Controllers
{
    
    public class CreateController : Controller
    {
        //Method to show the Create view
        public ActionResult Create()
        {
            
            if (Session["UserID"] == null)                                          //Check if the user is logged in
            {
                return RedirectToAction("LoggedOut", "Register");                   //If the user is not logged in, redirect to LoggedOut view
            }
            else
            {
                List<string> Categs = new List<string>();                           //Create and empty list and populate the categories for the list menu
                Categs.Add("Animal Rights");
                Categs.Add("Child Abuse");
                Categs.Add("Employee Rights");
                Categs.Add("Environment");
                Categs.Add("Health");
                Categs.Add("Racism");
                Categs.Add("Tax");
                Categs.Add("Other");

                ViewBag.Roles = new SelectList(Categs, "Title");                    //Save the list to a ViewBag in order to pass it to the view
                return View();
            }            
        }

        //Post method to add a new cause to the DbSet (the creator of the cause will not be counted as a supporter)
        [HttpPost]
        public ActionResult Create(Causes tempCause)
        {
            using (YourSayDB db = new YourSayDB())
            {
                if (ModelState.IsValid)                                             //Check if the form is complete
                {
                    db.Causes.Add(tempCause);                                       //Add the passed cause to the DbSet
                    db.SaveChanges();                                               //Save changed
                }
                ModelState.Clear();                                                 //Clear the form
                return RedirectToAction("Causes", "Causes");                        //Redirect to causes
            }
        }
    }
}