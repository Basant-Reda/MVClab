using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL;

namespace LabD04.MVC.Controllers;

public class TicketController : Controller
{
    private readonly ITicketManager _ticketManager;

    public TicketController(ITicketManager ticketManager)
    {
        _ticketManager = ticketManager;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetAll()
    {
        return View(_ticketManager.GetAll());
    }
    
    public IActionResult GetDetails(int id)
    {
        var ticket = _ticketManager.Get(id);
        if (ticket is null)
        {
            View("NotFoundDeveloper");
        }
        return View(ticket);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddVM ticket)
    {
        _ticketManager.Add(ticket);
        return RedirectToAction(nameof(GetAll));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ticket = _ticketManager.GetToEdit(id);
        return View(ticket);
    }

    [HttpPost]
    public IActionResult Edit(EditVM ticketVM)
    {
        _ticketManager.Edit(ticketVM);
        return RedirectToAction(nameof(GetAll));
    }

    [HttpPost]
    public IActionResult Delete(EditVM ticketVM)
    {
        _ticketManager.Delete(ticketVM);
        return RedirectToAction(nameof(GetAll));
    }
}
