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
    }
}