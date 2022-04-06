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
        public ActionResult Edit(int? id, string name, string role,string address,string mobile)
        {
            ViewBag.Message = "Your contact page.";

            return View(new Employee() { EmpId = id ?? 0, EmpRole = role, EmpName = name,EmpAddress=address,EmpMobile=mobile });
        }

        public ActionResult Delete(int? id, string name, string role,string address,string mobile)
        {
            ViewBag.Message = "Your contact page.";

            return View(new Employee() { EmpId = id ?? 0, EmpRole = role, EmpName = name,EmpAddress=address,EmpMobile=mobile });
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Message = "Your contact page.";

            var result = Employee.GetEmpDataByEmpId(id ?? 0);


            Employee newP = new Employee()
            {
                EmpId = Convert.ToInt32(result.Tables[0].Rows[0][0].ToString()),
                EmpName = result.Tables[0].Rows[0]["EmpName"].ToString(),
                EmpRole = result.Tables[0].Rows[0]["EmpRole"].ToString(),
                EmpAddress = result.Tables[0].Rows[0]["EmpAddress"].ToString(),
                EmpMobile = result.Tables[0].Rows[0]["EmpMobile"].ToString(),
               

            };
            return View(newP);
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
                    EmpRole = dataa[2].ToString(),
                    EmpAddress = dataa[3].ToString(),
                    EmpMobile = dataa[4].ToString()

                });
            }

            return View(e);
        }


        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {

                Employee newP = e;
                e.UpdateEmployee(e);
            }

            return RedirectToAction("ContactUs");
        }
        [HttpPost]
        public ActionResult Delete(Employee e)
        {
            if (ModelState.IsValid)
            {

                Employee.DeleteEmployee(e.EmpId);
            }

            return RedirectToAction("ContactUs");
        }




    }
}