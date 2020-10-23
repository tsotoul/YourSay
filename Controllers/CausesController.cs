using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourSay.Models;

namespace YourSay.Controllers
{

    public class CausesController : Controller
    { 
        Data db = Data.Instance;
        
        //Method to manually remove all causes from the DbSet (to be used only by the developer)
        public ActionResult Remove()
        {
            using (YourSayDB db = new YourSayDB())
            {
                db.Causes.RemoveRange(db.Causes);
                db.SaveChanges();
                return View();
            }
        }

        //Check if user is logged in and return the appropriate view
        public ActionResult Causes()
        {
            using (YourSayDB db = new YourSayDB())
            {
                if (Session["UserID"] == null)                                                          //Check if user is logged in 
                {
                    return View("CausesLoggedOut", db.Causes.ToList());                                     
                }
                else if(Session["Username"].ToString() == "admin1")
                {
                    return View("CausesAdmin", db.Causes.ToList());
                }
                else
                {
                    return View(db.Causes.ToList());
                }
                    
            }
        }

        //Action to remove all causes (not published, only for use by the creator to easily remove all causes)
        [HttpGet]
        public ActionResult RemoveCause(string title)
        {
            using(YourSayDB db = new YourSayDB())
            {

                db.Causes.Remove(db.Causes.First(c => c.Title == title));                               //Remove the cause with the title clicked
                db.SaveChanges();                                                                       //Save changes
                return RedirectToAction("Causes", "Causes");
            }
        }

        //Action to receive and process the 'Show supporters button' - returns a Json object
        [HttpPost]
        public JsonResult Show(string title)
        {
            using (YourSayDB db = new YourSayDB())
            {
                var tempCause = db.Causes.First(c => c.Title == title);                                 //Creates a temporary cause with the clicked title
                return Json(tempCause, JsonRequestBehavior.AllowGet);                                   //Returns the temporary cause as Jason
            }
        }

        //Action to receive and process the 'Sign to cause button' - Adds one to counter, the username to the Cause supporters and returns a Json object
        [HttpPost]
        public JsonResult Sign(int id)
        {
            using (YourSayDB db = new YourSayDB())
            {
                var usr = Session["Username"];                                                              //takes the username from the session

                if(db.Causes.FirstOrDefault(c => c.CauseId == id).Supporter.Contains(usr.ToString()))       //Check if the username already exists as a supporter
                {
                    var count = db.Causes.First(c => c.CauseId == id).Counter;                              //creates the count
                    return Json(count, JsonRequestBehavior.AllowGet);                                       //returns the count as Json
                } else
                {
                    db.Causes.FirstOrDefault(c => c.CauseId == id).Supporter += " " + usr.ToString();       //Adds the username to the cause supporters
                    db.Causes.First(c => c.CauseId == id).Counter++;                                        //Adds one to the counter
                    db.SaveChanges();                                                                       //Save changes

                    var count = db.Causes.First(c => c.CauseId == id).Counter;                              //creates the count
                    return Json(count, JsonRequestBehavior.AllowGet);                                       //returns the count as Json
                }
            }
        }
    }
}