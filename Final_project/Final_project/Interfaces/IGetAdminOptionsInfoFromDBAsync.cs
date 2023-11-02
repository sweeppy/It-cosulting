using Final_project.Models.AdminOptions;

namespace Final_project.Interfaces
{
    public interface IGetAdminOptionsInfoFromDBAsync
    {
        Task<List<BlogSection>> GetBlogSectionInfo();
        Task<BlogSection> GetBlogById(int id);
        Task<List<ContactSection>> GetContactSectionInfo();
        Task<List<FooterSection>>GetFooterSectionInfo();
        Task<List<HeaderSection>>GetHeaderSectionInfo();
        Task<List<ProjectsSection>> GetProjectsSectionInfo();
        Task<ProjectsSection> GetProjectById(int id);
        Task<List<ServicesSection>> GetServicesSectionInfo();
    }
}
