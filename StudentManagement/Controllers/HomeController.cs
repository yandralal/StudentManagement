using StudentManagement.Models;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {      
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Placeholder for authentication logic
                if (model.Email == "test@example.com" && model.Password == "password")
                {
                    Session["UserEmail"] = model.Email;
                    return RedirectToAction("List", "Student");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }       
    }
}