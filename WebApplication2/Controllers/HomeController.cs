using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
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

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View(new Employee());
        }

        [HttpPost]
        public ActionResult Create(Employee p)
        {
            if (ModelState.IsValid)
            {

                Employee newp = p;
                p.InsertEmployee(p);
            }

            return RedirectToAction("ContactUs");
        }

        public ActionResult ContactUs()
        {
            //Employee e = new Employee();
            //var data = e.GetEmpData();
            //e.EmpId = Convert.ToInt32(data.Tables[0].Rows[0][0].ToString());
            //e.EmpName = Convert.ToString(data.Tables[0].Rows[0][1].ToString());
            //e.EmpRole = Convert.ToString(data.Tables[0].Rows[0][2].ToString());

            //ViewBag.Message = "WELCOME TO THIS PAGE";
            List<Employee> e = new List<Employee>();
            var data = Employee.GetEmpData();
            foreach (DataRow dataa in data.Tables[0].Rows)
            {
                //Provider newProvider = new Provider()
                //{
                //    ProviderId = Convert.ToInt32(data[0].ToString()),
                //    ProviderName = data[1].ToString(),
                //    ProviderType = data[2].ToString()
                //};

                //p.Add(newProvider);

                e.Add(new Employee()
                {
                    EmpId = Convert.ToInt32(dataa[0].ToString()),
                    EmpName = dataa[1].ToString(),
                    EmpRole = dataa[2].ToString()
                });
            }

            return View(e);
        }
     

    }
}