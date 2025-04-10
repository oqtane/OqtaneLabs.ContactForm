using Oqtane.Models;
using Oqtane.Modules;

namespace OqtaneLabs.ContactForm
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Contact Form",
            Description = "Contact Form",
            Version = "6.1.2",
            ServerManagerType = "OqtaneLabs.ContactForm.Manager.ContactFormManager, OqtaneLabs.ContactForm.Server.Oqtane",
            SettingsType = "OqtaneLabs.ContactForm.Settings, OqtaneLabs.ContactForm.Client.Oqtane",
            PackageName = "OqtaneLabs.ContactForm"
        };
    }
}
