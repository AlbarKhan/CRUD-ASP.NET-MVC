using CRUD.Models;
using CRUD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        EmployeRepository employeRepository = new EmployeRepository();
        public ActionResult Index()
        {
            //var result = employeRepository.Get
            return View(employeRepository.GetAllEmployee());
        }

        [HttpGet]
        public ActionResult Create(EmployeModel employe)
        {
            var CurrentTime = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.CurrentTime = CurrentTime;
            return View(employe);
        }

        [HttpPost,ActionName("Create")]     
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include ="FirstName,LastName,Department,Email,Phone,BirthDate,UserName,Password")] EmployeModel employe)
        {
            employeRepository.InsertEmployee(employe);
            return RedirectToAction("Index");
        }
    }
}

