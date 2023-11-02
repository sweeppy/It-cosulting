using Final_project.Models.AdminOptions;

namespace Final_project.Models
{
    public class HomeMainModel
    {
        public List<BlogSection> BlogSection { get; set; }
        public List<ContactSection> ContactSection { get; set; }
        public List<FooterSection> FooterSection { get; set; }
        public List<HeaderSection> HeaderSection { get; set; }
        public List<ProjectsSection> ProjectsSection { get; set; }
        public List<ServicesSection> ServicesSection { get; set; }
    }
}
