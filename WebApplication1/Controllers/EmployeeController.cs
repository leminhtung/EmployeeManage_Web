using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.Webapiclient.GetAsync("User").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(empList);
        }
        public ActionResult AddEmp(int id = 0)
        {
            if(id == 0) 
                return View(new mvcEmployeeModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.Webapiclient.GetAsync("User/ViewDetail?id=" + id.ToString()).Result;
                var data = response.Content.ReadAsAsync<mvcEmployeeModel>().Result;
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult AddEmp(mvcEmployeeModel emp)
        {
            if (emp.UserId == 0)
            {
                HttpResponseMessage response = GlobalVariables.Webapiclient.PostAsJsonAsync("Admin", emp).Result;
                TempData["SuccessMessage"] = "Delete Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.Webapiclient.PutAsJsonAsync("Admin/Update" + emp.UserId,emp).Result;
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