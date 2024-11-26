using StudentManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext db = new StudentContext();
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var checkLoggedInUser = db.Login.SingleOrDefault(l => l.Username == model.Username);

                if(checkLoggedInUser != null)
                {
                    bool isValidUser = checkLoggedInUser.Username == model.Username && model.Password == "password";

                    if (isValidUser)
                    {
                        Session["UserEmail"] = model.Username;
                        return RedirectToAction("List", "Student");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                }                
            }

            return View(model);
        }       
    }
}