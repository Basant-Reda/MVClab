using LabD02.Models.Domain;
using LabD02.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;

namespace LabD02.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTicketList()
        {
            var tickets = Ticket.GetTicketList();
            return View(tickets);
        }
        [HttpGet] //get form to add ticket
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] //post new ticket to Ticket list
        public IActionResult Add(AddTicketVM ticket)
        {
            Ticket.AddtoTickets(ticket);
            return RedirectToAction(nameof(GetTicketList));
            
        }

    }
}
