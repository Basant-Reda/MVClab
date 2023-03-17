using TicketSystem.DAL;

namespace TicketSystem.BL;

public class TicketManager:ITicketManager
{
    private readonly ITicketRepo ticketRepo;

    public TicketManager(ITicketRepo ticketRepo)
	{
        this.ticketRepo = ticketRepo;
    }

    public void Add(AddVM ticket)
    {
        var newticket = new Ticket
        {
            Title = ticket.Title,
            Description = ticket.Desc,
            Severity = ticket.severity
        };

        ticketRepo.Add(newticket);
        ticketRepo.SaveChanges();
    }

    public void Delete(EditVM ticket)
    {
        ticketRepo.Delete(ticket.Id);
        ticketRepo.SaveChanges();
    }

    public void Edit(EditVM ticket)
    {
        var ticketToEdit = ticketRepo.Get(ticket.Id);

        ticketToEdit.Id = ticket.Id;
        ticketToEdit.Title = ticket.Title;
        ticketToEdit.Description = ticket.Desc;
        ticketToEdit.Severity = ticket.severity;


        ticketRepo.SaveChanges();

    }

    public TicketGetVM? Get(int id)
    {
        var ticket = ticketRepo.Get(id);
        if (ticket == null)
        {
            return null;
        }
        return new TicketGetVM(ticket.Id, ticket.Title, ticket.Description, ticket.Severity);
    }

    public List<TicketGetVM> GetAll()
    {
        var ticketsList = ticketRepo.GetAll();
        return ticketsList.Select(t => new TicketGetVM(t.Id, t.Title, t.Description, t.Severity))
            .ToList();
    }
  
       
    public EditVM? GetToEdit(int id)
    {
        var ticket = ticketRepo.Get(id);
        if (ticket== null)
        {
            return null;
        }
        return new EditVM(ticket.Id, ticket.Title, ticket.Description, ticket.Severity);
    }
}
