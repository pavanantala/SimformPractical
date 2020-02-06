using SimformWeb.Models;
using SimformWeb.Factory;
using System.Web.Mvc;
using SimformWeb.Common;


namespace SimformWeb.Controllers
{
    public class ProjectController : Controller
    {
        Notification notificationMessage = new Notification();
        private readonly ProjectModelFactory _projectModelFactory;

        public ProjectController()
        {
            _projectModelFactory = new ProjectModelFactory();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProject()
        {
            return Json(_projectModelFactory.PrepareProjectList(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddEditProject(int Id = 0)
        {
            ProjectEntity projectEntity = new ProjectEntity();
            if (Id > 0)
            {
                projectEntity = _projectModelFactory.PrepareProjectModelById(Id);
            }
            return View(projectEntity);
        }


        [HttpPost]
        public ActionResult AddEditProject(ProjectEntity projectEntity)
        {
            if (ModelState.IsValid)
            {
                _projectModelFactory.AddEditProjectFactory(projectEntity);
                
                return RedirectToAction("Index");
            }

            return View();
        }

        public JsonResult DeleteProject(int Id)
        {
            ;
            return Json(_projectModelFactory.DeleteProject(Id), JsonRequestBehavior.AllowGet);
        }
    }
}