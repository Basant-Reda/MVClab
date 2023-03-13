using LabD02.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LabD02.Models.View
{
    public record AddTicketVM
    {
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; init; } = DateOnly.FromDateTime(DateTime.Now);

        [Display(Name = "Is Closed")]
        public bool IsClosed { get; init; }
        public Severities Severity { get; init; }
        public string? Description { get; init; }
    }
}
