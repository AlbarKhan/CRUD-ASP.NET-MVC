using CRUD.Models;
using CRUD.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        EmployeRepository employeRepository = new EmployeRepository();
        public ActionResult Index(string mode,int? id)
        {
            var result = employeRepository.GetAllEmployee();
            if(!string.IsNullOrEmpty(mode) && id.HasValue)
            {
                switch(mode.ToLower())
                {
                    case "softdelete":
                        return DeleteConfirm(id.Value);
                    default:
                        return View(result);
                }
            }
            return View(result);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var emp = employeRepository.GetEmpById(id);
            Debug.WriteLine($"BirthDate: {emp.BirthDate}");
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,FirstName,LastName,Department,Email,Phone,BirthDate,UserName,Password")]EmployeModel employe)
        {
            try
            {
                employeRepository.UpdateEmployee(employe);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            employeRepository.SoftDeletEmployee(id);
            return RedirectToAction("Index");
        }
    }
}

