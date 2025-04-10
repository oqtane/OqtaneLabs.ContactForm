using System.Threading.Tasks;

namespace OqtaneLabs.ContactForm.Services
{
    public interface IContactFormService
    {
        Task AddContactFormAsync(Models.ContactForm ContactForm);
    }
}
