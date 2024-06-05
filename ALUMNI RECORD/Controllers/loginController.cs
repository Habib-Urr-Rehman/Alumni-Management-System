//using ALUMNI_RECORD.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;



//namespace ALUMNI_RECORD.Conroller
//{
//    public class loginController : Controller
//    {










//        [HttpGet]
//        public ActionResult loginpage()
//        {


//            List<Student> students = dbhandler.getAllstudent();



//            return View(students);
//        }

//        public ActionResult contaactus()
//        {

//            return View();
//        }

//        [HttpPost]
//        public ActionResult contaactus(string username, string password)
//        {
//            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//            {
//                ViewBag.ErrorMessage = "Please fill in both fields.";
//                return View();
//            }

//            User? user;
//            using (var context = new Deliverable3Context())
//            {
//                user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
//            }

//            if (user != null)
//            {
//                return RedirectToAction("loginpage");
//            }
//            else
//            {
//                ViewBag.ErrorMessage = "Invalid username or password.";
//                return View();
//            }
//        }



//        [HttpPost]
//        public ActionResult saveStudent(string sn, string sa)
//        {
//        Deliverable3Context db = new Deliverable3Context();
//            db.Students.Add(new Student { Sname = sn, Sage = sa });
//            db.SaveChanges();

//            return RedirectToAction("loginpage");
//        }

//        [HttpGet]
//        public IActionResult deleteStudent(int id)
//        {


//            using (Deliverable3Context db = new Deliverable3Context())
//            {
//                Student? obj = db.Students.Find(id);

//                db.Students.Remove(obj);
//                db.SaveChanges();
//            }

//            return RedirectToAction("loginpage", "login");
//        }

//        [HttpGet]

//        public IActionResult edit(int id)
//        {
//            Student? obj;
//            using (Deliverable3Context db = new Deliverable3Context())
//            {
//                obj = db.Students.Find(id);
//            }

//            return View("edit", obj);
//        }


//        [HttpPost]
//        public IActionResult edit(int id, string sn, string sa)
//        {
//            Student? obj;

//            using (Deliverable3Context db = new Deliverable3Context())
//            {
//                obj = db.Students.Find(id);


//                obj.Sname = sn;
//                obj.Sage = sa;
//                db.SaveChanges();



//            }



//            return RedirectToAction("loginpage");
//        }
//    }
//}




using ALUMNI_RECORD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ALUMNI_RECORD.Conroller
{
    public class loginController : Controller
    {
        [HttpGet]
        public ActionResult loginpage()
        {
            // Check if the session variable "myvalue" is set to 10
            if (HttpContext.Session.GetInt32("myvalue") != 10)
            {
                // If the session variable is not set, redirect to the contaactus action
                return RedirectToAction("contaactus");
            }

            List<Student> students = dbhandler.getAllstudent();
            return View(students);
        }

        //public ActionResult contaactus()
        //{
        //    // Check if the session variable "myvalue" is set to 10
        //    if (HttpContext.Session.GetInt32("myvalue") == 10)
        //    {
        //        // If the session variable is set, redirect to the loginpage action
        //        return RedirectToAction("loginpage");
        //    }

        //    return View();
        //}
        public ActionResult contaactus()
        {
            // Check if the session variable "myvalue" is not set to 10
            if (HttpContext.Session.GetInt32("myvalue") != 10)
            {
                // If the session variable is not set, display the login form
                return View();
            }
            else
            {
                // If the session variable is set, redirect to the loginpage action
                TempData["Message"] = "You are already logged in due to session.";
                return RedirectToAction("loginpage");
            }
        }

        [HttpPost]
        public ActionResult contaactus(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Please fill in both fields.";
                return View();
            }

            User? user;
            using (var context = new Deliverable3Context())
            {
                user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }

            if (user != null)
            {
                HttpContext.Session.SetInt32("myvalue", 10);
                return RedirectToAction("loginpage");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }

        [HttpPost]
        public ActionResult saveStudent(string sn, string sa)
        {
            if (HttpContext.Session.GetInt32("myvalue") != 10)
            {
                return RedirectToAction("contaactus");
            }

            Deliverable3Context db = new Deliverable3Context();
            db.Students.Add(new Student { Sname = sn, Sage = sa });
            db.SaveChanges();

            return RedirectToAction("loginpage");
        }

        [HttpGet]
        public IActionResult deleteStudent(int id)
        {
            if (HttpContext.Session.GetInt32("myvalue") != 10)
            {
                return RedirectToAction("contaactus");
            }

            using (Deliverable3Context db = new Deliverable3Context())
            {
                Student? obj = db.Students.Find(id);

                db.Students.Remove(obj);
                db.SaveChanges();
            }

            return RedirectToAction("loginpage");
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            if (HttpContext.Session.GetInt32("myvalue") != 10)
            {
                return RedirectToAction("contaactus");
            }

            Student? obj;
            using (Deliverable3Context db = new Deliverable3Context())
            {
                obj = db.Students.Find(id);
            }

            return View("edit", obj);
        }

        [HttpPost]
        public IActionResult edit(int id, string sn, string sa)
        {
            if (HttpContext.Session.GetInt32("myvalue") != 10)
            {
                return RedirectToAction("contaactus");
            }

            Student? obj;
            using (Deliverable3Context db = new Deliverable3Context())
            {
                obj = db.Students.Find(id);

                obj.Sname = sn;
                obj.Sage = sa;
                db.SaveChanges();
            }

            return RedirectToAction("loginpage");
        }


        [HttpGet]
        public IActionResult Logout()
        {
            // Clear the session variable "myvalue"
            HttpContext.Session.Remove("myvalue");

            // Redirect to the contaactus action or any other appropriate action after logout
            return RedirectToAction("contaactus");
        }
    }
}

