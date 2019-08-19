using Newtonsoft.Json;
using PagedList;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            HttpResponseMessage response = GlobalVariables.Webapiclient.GetAsync(string.Format("User/GetUser?searchstring={0}&page={1}&pagesize={2}", searchString, page, pageSize)).Result;
            //empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            string jsonstring = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<User>>(jsonstring);
            return View(result.ToPagedList(page, pageSize));
        }

        public ActionResult AddEmp(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
            {
                HttpResponseMessage response = GlobalVariables.Webapiclient.GetAsync("User/ViewDetail?id=" + id.ToString()).Result;
                var data = response.Content.ReadAsAsync<User>().Result;
                return View(data);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddEmp(User emp)
        {
            if (emp.UserId == 0)
            {
                HttpResponseMessage response = GlobalVariables.Webapiclient.PostAsJsonAsync("Admin/insert", emp).Result;
                TempData["SuccessMessage"] = "Insert Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.Webapiclient.PutAsJsonAsync("Admin/Update" + emp.UserId, emp).Result;
                TempData["SuccessMessage"] = "Update Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.Webapiclient.DeleteAsync("Admin/Delete?id=" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}