using SimformWeb.Models;
using SimformWeb.Factory;
using System.Web.Mvc;
using SimformWeb.Common;
using System.Collections.Generic;
using System;

namespace SimformWeb.Controllers
{
    public class EmployeeController : Controller
    {
        Notification notificationMessage = new Notification();
        private readonly EmployeeModelFactory _employeeModelFactory;
        private readonly ProjectModelFactory _projectModelFactory;

        public EmployeeController()
        {
            _employeeModelFactory = new EmployeeModelFactory();
            _projectModelFactory = new ProjectModelFactory();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployee()
        {
            return Json(_employeeModelFactory.PrepareEmployeeList(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddEditEmployee(int Id=0)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            if (Id > 0)
            {
                employeeEntity = _employeeModelFactory.PrepareEmployeeModelById(Id);
            }
            return View(employeeEntity);
        }


        [HttpPost]
        public ActionResult AddEditEmployee(EmployeeEntity employeeEntity)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeModelFactory.AddEditEmployeeFactory(employeeEntity);
                if (result.Success == false)
                {
                    notificationMessage.Message = "Something went wrong";
                    notificationMessage.Type = NotificationType.Error;

                    TempData["NotificationMessage"] = notificationMessage;
                }

                else
                {
                    notificationMessage.Message = result.Message;
                    notificationMessage.Type = NotificationType.Success;

                    TempData["NotificationMessage"] = notificationMessage;
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        public JsonResult DeleteEmployee(int Id)
        {
            return Json(_employeeModelFactory.DeleteEmployee(Id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmployeeToProjectIndex(int id = 0)
        {
            return View();
        }
        public JsonResult GetEmployeeToProjectList(DateTime? JoiningDate, string EmpName, string ProjName)
        {
            return Json(_employeeModelFactory.PrepareEmployeeToProjectList( JoiningDate,  EmpName,  ProjName), JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public ActionResult AddEditEmployeeToProject(int Id = 0)
        {
            var EmpList = _employeeModelFactory.PrepareEmployeeList();
            ViewBag.Employees = new SelectList(EmpList, "Id", "FullName") { };

            var ProjectList = _projectModelFactory.PrepareProjectList();
            ViewBag.Projects = new SelectList(ProjectList, "Id", "Name") { };

            EmployeeToProjectEntity employeeEntity = new EmployeeToProjectEntity();
            if (Id > 0)
            {
                employeeEntity = _employeeModelFactory.PrepareEmployeeToProjectModelById(Id);
            }
            return View(employeeEntity);
        }


        [HttpPost]
        public ActionResult AddEditEmployeeToProject(EmployeeToProjectEntity employeeEntity)
        {
            if (ModelState.IsValid)
            {
                 _employeeModelFactory.AddEditEmployeeToProjectFactory(employeeEntity);
                return RedirectToAction("EmployeeToProjectIndex");
            }

            return View();
        }

        public JsonResult DeleteEmployeeToProject(int Id)
        {
            return Json(_employeeModelFactory.DeleteEmployeeToProject(Id), JsonRequestBehavior.AllowGet);
        }
    }
}