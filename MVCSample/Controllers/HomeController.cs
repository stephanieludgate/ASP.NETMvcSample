using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Test = "This is a test";

            return View();
        }

        public ActionResult Steph(int number)
        {
            IList<int> myList = new List<int>() { 1, 2, 3, 4, 5 };

            ViewBag.Message = $"Hello from User_{number}.";
            ViewBag.MyList = myList;

            return View(); // can return a different view: return View("Index") **URL will remain Home/Steph/number
            // We can also use return RedirectToAction("Contact") ** URL will be Home/Contact
        }

        public string HelloWorld(string firstName, string lastName)
        {
            return $"Hello world from {firstName} {lastName}!";
        }

        public string GetUser(int number)
        {
            return $"Hello from User_{number}";
            // we can access this by: /home/getuser?id=10 OR home/getuser/10
        }
    }
}