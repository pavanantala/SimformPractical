using SimformWeb.Models;
using SimformWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimformWeb.Factory
{
    public class ProjectModelFactory
    {
        private readonly ProjectService projectService;

        public ProjectModelFactory()
        {
            projectService = new ProjectService();
        }

        public List<ProjectEntity> PrepareProjectList()
        {
            List<ProjectEntity> projectList = new List<ProjectEntity>();
            var pList = projectService.GetProjectList();
            if (pList.Count > 0)
            {
                foreach (var list in pList)
                {
                    var tList = new ProjectEntity();
                    tList.Id = list.Id;
                    tList.Name = list.Name;
                    tList.Cost = list.Cost ?? 0;
                    
                    projectList.Add(tList);
                }
            }

            return projectList;
        }

        public ProjectEntity PrepareProjectModelById(int id)
        {
            var projectEntity = new ProjectEntity();

            var project = projectService.GetProjectById(id);
            if (project != null)
            {
                projectEntity.Id = project.Id;
                projectEntity.Name = project.Name;
                projectEntity.Cost = project.Cost ?? 0;
            }
            return projectEntity;
        }

        public void AddEditProjectFactory(ProjectEntity projectEntity)
        {
            if (projectEntity.Id> 0)
            {
                projectService.Update(projectEntity);
            }
            else
            {
                projectService.Insert(projectEntity);
            }
            
        }

        public ResultValue DeleteProject(int id)
        {
            return projectService.Delete(id);
        }
    }
}