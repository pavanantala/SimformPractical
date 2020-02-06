using SimformWeb.Models;
using SimformWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimformWeb.Factory
{
    public class EmployeeModelFactory
    {
        private readonly EmployeeService employeeService;

        public EmployeeModelFactory()
        {
            employeeService = new EmployeeService();
        }


        public List<EmployeeToProjectEntity> PrepareEmployeeToProjectList(DateTime? JoiningDate, string EmpName, string ProjName)
        {
            //List<EmployeeToProjectEntity> employeeList = new List<EmployeeToProjectEntity>();
            //var empList = employeeService.GetEmployeeToProjectList( JoiningDate,  EmpName,  ProjName);
            //if (empList.Count > 0)
            //{

            //    //foreach (var list in empList)
            //    //{
            //    //    var tList = new EmployeeToProjectEntity();
            //    //    tList.Id = list.Id;
            //    //    tList.FullName = (list.Employee.FirstName + " " + (list.Employee.LastName ?? " "));
            //    //    tList.JoiningDateString = list.Employee.JoiningDate.ToString("dd/MMM/yyyy");
            //    //    tList.Name = list.Project.Name;
            //    //    tList.Cost = list.Project.Cost ?? 0;

            //    //    employeeList.Add(tList);
            //    //}
            //}

            //return employeeList;

            return employeeService.GetEmployeeToProjectList(JoiningDate, EmpName, ProjName);
        }

        public List<EmployeeEntity> PrepareEmployeeList()
        {
            List<EmployeeEntity> employeeList = new List<EmployeeEntity>();
            var empList = employeeService.GetEmployeeList();
            if (empList.Count > 0)
            {
                foreach (var list in empList)
                {
                    var tList = new EmployeeEntity();
                    tList.Id = list.Id;
                    tList.FirstName = list.FirstName;
                    tList.LastName = list.LastName;
                    tList.JoiningDate = list.JoiningDate;
                    tList.JoiningDateString = tList.JoiningDate.ToString("dd/MMM/yyyy");
                    tList.Salary = list.Salary;

                    employeeList.Add(tList);
                }
            }

            return employeeList;
        }

        public EmployeeEntity PrepareEmployeeModelById(int id)
        {
            var employeeEntity = new EmployeeEntity();

            var emp = employeeService.GetEmployeeById(id);
            if (emp != null)
            {
                employeeEntity.Id = emp.Id;
                employeeEntity.FirstName = emp.FirstName;
                employeeEntity.LastName = emp.LastName;
                employeeEntity.JoiningDate = emp.JoiningDate;
                employeeEntity.Salary = emp.Salary;
            }
            return employeeEntity;
        }

        public ResultValue AddEditEmployeeFactory(EmployeeEntity employeeEntity)
        {
            return employeeService.AddEditEmployeeById(employeeEntity);
        }

        public ResultValue DeleteEmployee(int Id)
        {
            return employeeService.DeleteEmployee(Id);
        }

        public ResultValue DeleteEmployeeToProject(int Id)
        {
            return employeeService.DeleteEmployeeToProject(Id);
        }

        public EmployeeToProjectEntity PrepareEmployeeToProjectModelById(int id)
        {
            var employeetoProjectEntity = new EmployeeToProjectEntity();

            var emptoProj = employeeService.GetEmployeeToProjectById(id);
            if (emptoProj != null)
            {
                employeetoProjectEntity.Id = emptoProj.Id;
                employeetoProjectEntity.EmpId = emptoProj.EmpId ?? 0;
                employeetoProjectEntity.ProjectId = emptoProj.ProjectId ?? 0;
            }
            return employeetoProjectEntity;
        }

        public void AddEditEmployeeToProjectFactory(EmployeeToProjectEntity employeeToProjectEntity)
        {
            if (employeeToProjectEntity.Id > 0)
            {
                employeeService.UpdateEmployeeToProject(employeeToProjectEntity);
            }
            else
            {
               employeeService.InsertEmployeeToProject(employeeToProjectEntity);
            }
        }
    }
}