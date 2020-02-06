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
    public class ProjectService
    {
        private readonly GenericRepository<Project> _repositoryProject;

        public ProjectService()
        {
            _repositoryProject = new GenericRepository<Project>();
        }

        public List<Project> GetProjectList()
        {
            return _repositoryProject.Table.ToList();
        }

        public Project GetProjectById(int Id)
        {
            return _repositoryProject.GetById(Id);
        }

        public void Insert(ProjectEntity projectEntity)
        {
            Project project = new Project();
            project.Id = projectEntity.Id;
            project.Name = projectEntity.Name;
            project.Cost = projectEntity.Cost;

            _repositoryProject.Insert(project);
            _repositoryProject.SaveChanges();
        }

        public void Update(ProjectEntity projectEntity)
        {
            Project project = new Project();
            project.Id = projectEntity.Id;
            project.Name = projectEntity.Name;
            project.Cost = projectEntity.Cost;

            _repositoryProject.Update(project);
            _repositoryProject.SaveChanges();
        }

        public ResultValue Delete(int Id)
        {
            var response = new ResultValue();
            try
            {
                var pIDParam = new SqlParameter
                {
                    ParameterName = "Id",
                    DbType = DbType.Int32,
                    Value = Id
                };

                var result = _repositoryProject.ExecuteSQL<string>("DeleteProjectById", pIDParam).FirstOrDefault();
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
    }
}