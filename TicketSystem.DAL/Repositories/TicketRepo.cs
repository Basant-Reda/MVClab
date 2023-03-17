

namespace TicketSystem.DAL;

public class TicketRepo : ITicketRepo
{
    private readonly TicketsContext _context;
    public TicketRepo(TicketsContext context)
    {
        _context = context;
    }
    public IEnumerable<Ticket> GetAll()
    {
        
        return _context.Set<Ticket>();
    }

    public Ticket? Get(int id)
    {
        
        return _context.Set<Ticket>().Find(id);
        
    }

    public void Add(Ticket ticket)
    {
        
        _context.Set<Ticket>().Add(ticket);
    }

    public void Update(Ticket ticket)
    {
    }

    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Set<Ticket>().Remove(ticketToDelete); //set<ticket> ? get table that map to class ticket 
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
