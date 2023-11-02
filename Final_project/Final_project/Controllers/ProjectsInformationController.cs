using Final_project.Models.AdminOptions;
using Microsoft.AspNetCore.Mvc;
using Final_project.Interfaces;

namespace Final_project.Controllers
{
    public class ProjectsInformationController : Controller
    {
        IGetAdminOptionsInfoFromDBAsync _Iadmin;

        public ProjectsInformationController(IGetAdminOptionsInfoFromDBAsync iAdmin)
        {
            _Iadmin = iAdmin;
        }
        public  async Task<IActionResult> Index(int id)
        {
            ProjectsSection project = await _Iadmin.GetProjectById(id);

            return View(project);
        }
    }
}
