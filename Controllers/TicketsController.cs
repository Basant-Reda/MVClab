using lab3.Models.Domain;
using lab3.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;

namespace lab3.Controllers
{
    public class TicketsController : Controller
    {
        public List<Ticket> tickets = Ticket.GetTickets();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return View(tickets);
        }
        public IActionResult Details(Guid? id)
        {
            if (id == null || tickets == null)
            {
                return NotFound();
            }
            var ticket = tickets.FirstOrDefault(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        [HttpGet]
        public IActionResult Add()
        {
            GetData();            
            return View();
        }

        [HttpPost]
        public IActionResult Add(TicketVM ticketVM)
        {
            var dept = GetOneDepartment(ticketVM);
            var devs = GetDevs(ticketVM);
            Ticket ticket = new Ticket
            {
                Id= Guid.NewGuid(),
                CreatedDate = ticketVM.CreatedDate,
                Description = ticketVM.Description,
                IsClosed = ticketVM.IsClosed,
                Severity=ticketVM.Severity,
                Department= dept,
                Developers= devs

            };
            tickets.Add(ticket);
            return RedirectToAction(nameof(GetAll));
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            GetData();

            var ticketToEdit = tickets.First(a => a.Id == id);
            var newTicket = new EditTicketVM
            {
                Id = ticketToEdit.Id,
                CreatedDate= ticketToEdit.CreatedDate,
                Description= ticketToEdit.Description,
                DeveloperIds= ticketToEdit.Developers.Select(d=>d.Id).ToList(),
                IsClosed= ticketToEdit.IsClosed,
                Severity=ticketToEdit.Severity,
                Department= ticketToEdit.Department.Id,

            };

            return View(newTicket);
        }

        [HttpPost]
        public IActionResult Edit(EditTicketVM newTicket)
        {
            var dept = GetOneDepartment(newTicket);
            var devs = GetDevs(newTicket);

            var ticketToEdit = tickets.First(a => a.Id == newTicket.Id);

            ticketToEdit.CreatedDate = newTicket.CreatedDate;
            ticketToEdit.IsClosed = newTicket.IsClosed;
            ticketToEdit.Severity = newTicket.Severity;
            ticketToEdit.Department = dept;
            ticketToEdit.Developers = devs;
            ticketToEdit.Description = newTicket.Description;

            return RedirectToAction(nameof(GetAll));
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var ticketToDelete = tickets.FirstOrDefault(a => a.Id == id);
            tickets.Remove(ticketToDelete);

            return RedirectToAction(nameof(GetAll));
        }

        private void GetData()
        {
            var departments = Department.GetDepartments().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            ViewBag.departments = departments;
            var developers = Developer.GetDevelopers().Select(a => new SelectListItem($"{a.FirstName} {a.LastName}", a.Id.ToString())); 
            ViewBag.developers = developers;
            

        }
        private static Department GetOneDepartment(TicketVM ticketVM)
        {
            return Department.GetDepartments().FirstOrDefault(d => d.Id == ticketVM.Department);
        }
        private static List<Developer> GetDevs(TicketVM ticketVM)
        {
            return Developer.GetDevelopers().Where(d => ticketVM.DeveloperIds.Contains(d.Id)).ToList();
        }
    }

}
