using StudentManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext db = new StudentContext();
        public StudentController()
        {
        }

        // GET: Student/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Student/Register
        [HttpPost]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                return RedirectToAction("List", "Student");
            }
            return View(student);
        }

        // GET: Student/List
        public ActionResult List()
        {
            if (Session["UserEmail"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var students = db.Students.ToList();
            return View(students);
        }

        // GET: Student/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        // GET: Student/Delete
        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(student);
        }
    }
}
