using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public void Kill()
        {
            System.Console.Out.WriteLine("Faster, Pussycat! Kill! Kill!");
            System.Environment.Exit(1);
        }
    }
}
