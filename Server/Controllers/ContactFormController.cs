using Microsoft.AspNetCore.Mvc;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Microsoft.AspNetCore.Http;
using Oqtane.Controllers;
using Oqtane.Models;
using System.Net;
using Oqtane.Repository;

namespace OqtaneLabs.ContactForm.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class ContactFormController : ModuleControllerBase
    {
        private readonly INotificationRepository _notifications;
        private readonly IVisitorRepository _visitors;

        public ContactFormController(INotificationRepository notifications, IVisitorRepository visitors, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _notifications = notifications;
            _visitors = visitors;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Models.ContactForm ContactForm)
        {
            if (ModelState.IsValid)
            {
                var body = $"Name: {WebUtility.HtmlEncode(ContactForm.Name)}<br />Email: {WebUtility.HtmlEncode(ContactForm.Email)}<br />Message: {WebUtility.HtmlEncode(ContactForm.Message)}";

                var visitor = _visitors.GetVisitor(ContactForm.VisitorId);
                if (visitor != null)
                {
                    body += $"<br />Visitor Id: {ContactForm.VisitorId}<br />Last Visit: {visitor.VisitedOn}<br />First Visit: {visitor.CreatedOn}<br />Total Visits: {visitor.Visits}";
                }

                var notification = new Notification(ContactForm.SiteId, "", ContactForm.Recipient, ContactForm.Title, body);
                _notifications.AddNotification(notification);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Notification Added {Notification}", notification);

                if (!string.IsNullOrEmpty(ContactForm.Response))
                {
                    notification = new Notification(ContactForm.SiteId, ContactForm.Name, ContactForm.Email, ContactForm.Title, ContactForm.Response);
                    _notifications.AddNotification(notification);
                    _logger.Log(LogLevel.Information, this, LogFunction.Create, "Notification Added {Notification}", notification);
                }
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized ContactForm Post Attempt {ContactForm}", ContactForm);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                ContactForm = null;
            }
        }

    }
}
