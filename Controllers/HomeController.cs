using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourSay.Models;

namespace YourSay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            using (YourSayDB db = new YourSayDB())
            {
                return View(db.Causes.Take(3).ToList());        //Return the first 3 causes from the DbSet
            }
        }

    }
}