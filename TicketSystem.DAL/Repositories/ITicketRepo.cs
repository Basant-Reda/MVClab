
namespace TicketSystem.DAL;

public interface ITicketRepo
{
IEnumerable<Ticket> GetAll();
    Ticket? Get(int id);
    void Add(Ticket ticket);
    void Update(Ticket ticket);
    void Delete(int id);
    int SaveChanges();
}
