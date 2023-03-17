
namespace TicketSystem.BL;

public interface ITicketManager
{
    List<TicketGetVM> GetAll();
    TicketGetVM? Get(int id);
    EditVM? GetToEdit(int id);
    void Add(AddVM ticket);
    void Edit(EditVM ticket);

    void Delete(EditVM ticket);
}
