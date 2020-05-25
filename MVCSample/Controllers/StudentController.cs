using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            // Using DUMMY items
            //MvcApplication.studentsList.Clear(); // clear before adding default/dummy records 
            //MvcApplication.studentsList.Add(new Models.Student() { StudentId = 5, StudentName = "Steph", Age = 30 });
            //MvcApplication.studentsList.Add(new Models.Student() { StudentId = 6, StudentName = "Devon", Age = 27 });

            return View(MvcApplication.studentsList); // created view
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(GetStudentById(id)); 
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();  // created
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(MVCSample.Models.Student std)
        {
            try
            {
                // TODO: Add insert logic here
                std.StudentId = ++MvcApplication.globalStudentId;
                MvcApplication.studentsList.Add(std);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetStudentById(id));  
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MVCSample.Models.Student std)
        {
            try
            {
                // TODO: Add update logic here
                Student selectedStudent = GetStudentById(id);
                selectedStudent.StudentName = std.StudentName;
                selectedStudent.Age = std.Age;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetStudentById(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MvcApplication.studentsList.Remove(GetStudentById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public Student GetStudentById(int id)
        {
            return MvcApplication.studentsList.Where(s => s.StudentId == id).FirstOrDefault();
        }
    }
}
