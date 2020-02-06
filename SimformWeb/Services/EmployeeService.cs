using SimformWeb.Data;
using SimformWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimformWeb.Services
{
    public class EmployeeService
    {

        private readonly GenericRepository<Employee> _repositoryEmployee;
        private readonly GenericRepository<EmployeeToProject> _repositoryEmployeeToProject;

        public EmployeeService()
        {
            _repositoryEmployee = new GenericRepository<Employee>();
            _repositoryEmployeeToProject = new GenericRepository<EmployeeToProject>();
        }

        public List<Employee> GetEmployeeList()
        {
            return _repositoryEmployee.Table.ToList();
        }

        public Employee GetEmployeeById(int Id)
        {
            var result = new Employee();

            var empIDParam = new SqlParameter
            {
                ParameterName = "Id",
                DbType = DbType.Int32,
                Value = Id
            };

            result = _repositoryEmployee.ExecuteSQL<Employee>("GetEmployeeById", empIDParam).FirstOrDefault();


            return result;
        }

        public ResultValue AddEditEmployeeById(EmployeeEntity employee)
        {
            var response = new ResultValue();
            try
            {
                var empIDParam = new SqlParameter
                {
                    ParameterName = "Id",
                    DbType = DbType.Int32,
                    Value = (object)employee.Id ?? DBNull.Value
                };
                var firstNameParam = new SqlParameter
                {
                    ParameterName = "FirstName",
                    DbType = DbType.String,
                    Value = employee.FirstName
                };
                var lastNameParam = new SqlParameter
                {
                    ParameterName = "LastName",
                    DbType = DbType.String,
                    Value = (object)employee.LastName ?? DBNull.Value
                };
                var joiningDateParam = new SqlParameter
                {
                    ParameterName = "JoiningDate",
                    DbType = DbType.DateTime,
                    Value = employee.JoiningDate
                };
                var salaryParam = new SqlParameter
                {
                    ParameterName = "Salary",
                    DbType = DbType.Decimal,
                    Value = employee.Salary
                };
                var result = _repositoryEmployee.ExecuteSQL<string>("AddEditEmployee",
                                                                 empIDParam,
                                                                 firstNameParam,
                                                                 lastNameParam,
                                                                 joiningDateParam,
                                                                 salaryParam).FirstOrDefault();
                if (result != "")
                {
                    response.Success = true;
                    response.Message = result;
                }
                else
                {
                    response.Success = false;
                    response.Message = "";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }

        }

        public ResultValue DeleteEmployee(int Id)
        {
            var response = new ResultValue();
            try
            {
                var empIDParam = new SqlParameter
                {
                    ParameterName = "Id",
                    DbType = DbType.Int32,
                    Value = Id
                };

                var result = _repositoryEmployee.ExecuteSQL<string>("DeleteEmployeeById", empIDParam).FirstOrDefault();
                if (result != "")
                {
                    response.Success = true;
                    response.Message = result;
                }
                else
                {
                    response.Success = false;
                    response.Message = "";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public List<EmployeeToProjectEntity> GetEmployeeToProjectList(DateTime? JoiningDate, string EmpName, string ProjName)
        {
            var result = new List<EmployeeToProjectEntity>();

            var empParam = new SqlParameter
            {
                ParameterName = "EmployeeName",
                DbType = DbType.String,
                Value = (object)EmpName ?? ""
            };
            var projParam = new SqlParameter
            {
                ParameterName = "ProjectName",
                DbType = DbType.String,
                Value = (object)ProjName ??""
            };
            var jdParam = new SqlParameter
            {
                ParameterName = "JoiningDate",
                DbType = DbType.DateTime,
                Value = (object)JoiningDate ?? DBNull.Value
            };

            result = _repositoryEmployee.ExecuteSQL<EmployeeToProjectEntity>("GetProjectAssignListToEmployee", empParam,projParam,jdParam).ToList();


            return result;
            //return _repositoryEmployeeToProject.Table.ToList();
        }


        public ResultValue DeleteEmployeeToProject(int Id)
        {
            var response = new ResultValue();
            try
            {
                var empIDParam = new SqlParameter
                {
                    ParameterName = "Id",
                    DbType = DbType.Int32,
                    Value = Id
                };

                var result = _repositoryEmployee.ExecuteSQL<string>("DeleteEmployeeToProjectById", empIDParam).FirstOrDefault();
                if (result != "")
                {
                    response.Success = true;
                    response.Message = result;
                }
                else
                {
                    response.Success = false;
                    response.Message = "";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public EmployeeToProject GetEmployeeToProjectById(int Id)
        {
            return _repositoryEmployeeToProject.GetById(Id);
        }

        public void InsertEmployeeToProject(EmployeeToProjectEntity employeeToProjectEntity)
        {
            EmployeeToProject employeeToProject = new EmployeeToProject();
            employeeToProject.Id = employeeToProjectEntity.Id;
            employeeToProject.EmpId = employeeToProjectEntity.EmpId;
            employeeToProject.ProjectId = employeeToProjectEntity.ProjectId;

            if (!_repositoryEmployeeToProject.Table.Any(x => x.ProjectId == employeeToProject.ProjectId &&
                                                         x.EmpId == employeeToProject.EmpId))
            {
                _repositoryEmployeeToProject.Insert(employeeToProject);
                _repositoryEmployeeToProject.SaveChanges();
            }
        }

        public void UpdateEmployeeToProject(EmployeeToProjectEntity employeeToProjectEntity)
        {
            EmployeeToProject employeeToProject = new EmployeeToProject();
            employeeToProject.Id = employeeToProjectEntity.Id;
            employeeToProject.EmpId = employeeToProjectEntity.EmpId;
            employeeToProject.ProjectId = employeeToProjectEntity.ProjectId;

            _repositoryEmployeeToProject.Update(employeeToProject);
            _repositoryEmployeeToProject.SaveChanges();
        }
    }
}