using Final_project.Interfaces;
using Final_project.Models.AdminOptions;
using Newtonsoft.Json;

namespace Final_project.Data
{
    public class GetInfoFromDBApi : IGetAdminOptionsInfoFromDBAsync
    {
        HttpClient _httpClient;

        public GetInfoFromDBApi()
        {
            _httpClient = new HttpClient();
        }
        /// <summary>
        /// Get info about blog section from api
        /// </summary>
        /// <returns></returns>
        public async Task<List<BlogSection>> GetBlogSectionInfo()
        {
            string url = @"https://localhost:7105/api/admin/GetBlogSection";

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<List<BlogSection>>(response);

            return result;
        }
        /// <summary>
        /// Get info about one blog from api
        /// </summary>
        /// <returns></returns>
        public async Task<BlogSection> GetBlogById(int id)
        {
            string url = @"https://localhost:7105/api/admin/GetBlogById/" + id;

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<BlogSection>(response);

            return result;
        }
        /// <summary>
        /// Get info about Contacts section from api
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContactSection>> GetContactSectionInfo()
        {
            string url = @"https://localhost:7105/api/admin/GetContactSection";

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<List<ContactSection>>(response);

            return result;

        }
        /// <summary>
        /// Get info about footer section from api
        /// </summary>
        /// <returns></returns>
        public async Task<List<FooterSection>> GetFooterSectionInfo()
        {
            string url = @"https://localhost:7105/api/admin/GetFooterSection";

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<List<FooterSection>>(response);

            return result;
        }
        /// <summary>
        /// Get info about header section from api
        /// </summary>
        /// <returns></returns>
        public async Task<List<HeaderSection>> GetHeaderSectionInfo()
        {
            string url = @"https://localhost:7105/api/admin/GetHeaderSection";

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<List<HeaderSection>>(response);

            return result;
        }
        /// <summary>
        /// Get info about projects section from api
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProjectsSection>> GetProjectsSectionInfo()
        {
            string url = @"https://localhost:7105/api/admin/GetProjectsSection";

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<List<ProjectsSection>>(response);

            return result;
        }
        /// <summary>
        /// Get info about concrete project from api
        /// </summary>
        /// <returns></returns>
        public async Task<ProjectsSection> GetProjectById(int id)
        {
            string url = @"https://localhost:7105/api/admin/GetProjectById/" + id;

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<ProjectsSection>(response);

            return result;
        }
        /// <summary>
        /// Get info about services section from api
        /// </summary>
        /// <returns></returns>
        public async Task<List<ServicesSection>> GetServicesSectionInfo()
        {
            string url = @"https://localhost:7105/api/admin/GetServicesSection";

            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<List<ServicesSection>>(response);

            return result;
        }
    }
}
