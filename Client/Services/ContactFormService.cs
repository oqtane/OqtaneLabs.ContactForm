using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace OqtaneLabs.ContactForm.Services
{
    public class ContactFormService : ServiceBase, IContactFormService, IService
    {
        public ContactFormService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string ApiUrl => CreateApiUrl("ContactForm");

        public async Task AddContactFormAsync(Models.ContactForm ContactForm)
        {
           await PostJsonAsync(ApiUrl, ContactForm);
        }
    }
}
