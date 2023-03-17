
using TicketSystem.DAL;

namespace TicketSystem.BL;

public record TicketGetVM(int Id, string Title, string Desc, Severity severity) { };

