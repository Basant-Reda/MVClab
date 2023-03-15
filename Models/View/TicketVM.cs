using lab3.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab3.Models.View
{
    public record TicketVM
    {
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; init; }= DateOnly.FromDateTime(DateTime.Now);

        [Display(Name = "Is Closed")]
        public bool IsClosed { get; init; }
        public Severity Severity { get; init; }
        public string Description { get; init; }=string.Empty;
        public Guid Department { get; set; }
        public ICollection<Guid> DeveloperIds { get; set; } = new List<Guid>();
    }
}
