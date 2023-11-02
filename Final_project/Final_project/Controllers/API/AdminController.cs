using Final_project.Data;
using Final_project.Models.AdminOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        MssqladminOptionsDbContext _context;

        public AdminController(MssqladminOptionsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// return BlogSection list from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBlogSection")]
        public async Task<ActionResult<IEnumerable<BlogSection>>> GetBlogSection()
        {
            return await _context.BlogSections.ToListAsync();
        }

        /// <summary>
        /// return inf about one blog from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBlogById/{id}")]
        public async Task<ActionResult<BlogSection>> GetBlogById(int id)
        {
            var blogs = await _context.BlogSections.ToListAsync();
            return blogs.ElementAt(id - 1);//element starts at 0, but id starts at 1, that's why id-1
        }

        /// <summary>
        /// return ContactSection list from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetContactSection")]
        public async Task<ActionResult<IEnumerable<ContactSection>>> GetContactSection()
        {
            return await _context.ContactSections.ToListAsync();
        }

        /// <summary>
        /// return FooterSection list from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetFooterSection")]
        public async Task<ActionResult<IEnumerable<FooterSection>>> GetFooterSection()
        {
            return await _context.FooterSections.ToListAsync();
        }

        /// <summary>
        /// return HeaderSection list from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetHeaderSection")]
        public async Task<ActionResult<IEnumerable<HeaderSection>>> GetHeaderSection()
        {
            return await _context.HeaderSections.ToListAsync();
        }

        /// <summary>
        /// return ProjectsSection list from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetProjectsSection")]
        public async Task<ActionResult<IEnumerable<ProjectsSection>>> GetProjectsSection()
        {
            return await _context.ProjectsSections.ToListAsync();
        }
        [HttpGet, Route("GetProjectById/{id}")]
        public async Task<ActionResult<ProjectsSection>> GetProjectById(int id)
        {
            var projects = await _context.ProjectsSections.ToListAsync();
            return projects.ElementAt(id - 1); //element starts at 0, but id starts at 1, that's why id-1
        }

        /// <summary>
        /// return ServicesSection list from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetServicesSection")]
        public async Task<ActionResult<IEnumerable<ServicesSection>>> GetServicesSection()
        {
            return await _context.ServicesSections.ToListAsync();
        }

    }
}
