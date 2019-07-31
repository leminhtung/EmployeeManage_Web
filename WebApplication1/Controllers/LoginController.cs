using System.Net.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel emp)
        {
            HttpResponseMessage response = GlobalVariables.Webapiclient.PostAsJsonAsync("Admin",emp).Result;
            var a = response.Content.ReadAsAsync<bool>().Result;
            if (a)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("", "LoginID hoặc Password bị sai");
            }
            return View("Index");
        }
    }
}