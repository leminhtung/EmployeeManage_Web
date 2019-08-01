using System.Net.Http;
using System.Web.Mvc;
using WebApplication1.Common;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonContants.ADMIN_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(LoginModel emp)
        {
            HttpResponseMessage response = GlobalVariables.Webapiclient.PostAsJsonAsync("Admin",emp).Result;
            var a = response.Content.ReadAsAsync<bool>().Result;
            if (a)
            {
                var adminSesion = new LoginAdmin();
                Session.Add(CommonContants.ADMIN_SESSION, adminSesion);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("", "LoginID or password is wrong");
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Register(mvcEmployeeModel emp)
        {
            HttpResponseMessage response = GlobalVariables.Webapiclient.PostAsJsonAsync("Admin", emp).Result;
            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("Index");
        }
    }
}