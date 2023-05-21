using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ConcertDB.DAL.Entities
{
    public class Tickets
    {
        [Display(Name = "Tickets")]
        [Required]
        public Guid Id { get; set; }

        public DateOnly? UseDate { get; set; }

        public Boolean IsUsed { get; set; }

        public String? EntranceGate { get; set; }

    }
}
