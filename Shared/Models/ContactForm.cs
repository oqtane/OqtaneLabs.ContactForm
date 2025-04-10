namespace OqtaneLabs.ContactForm.Models
{
    public class ContactForm
    {
        public int SiteId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string Recipient { get; set; }
        public string Response { get; set; }
        public int VisitorId { get; set; }
    }
}
