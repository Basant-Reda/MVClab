using lab3.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab3.Models.View
{
    public record EditTicketVM:TicketVM
    {
        public Guid Id { get; init; }
    }
}
