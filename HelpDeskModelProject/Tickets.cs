using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskModelProject
{
    public class Tickets
    {
        public Tickets()
        {

        }

        [Key]
        public int TicketID { get; set; }
        public int TicketSubmitterID { get; set; }
        public User TicketSubmitter { get; set; }
        public int? TicketResolverID { get; set; }
        public User? TicketResolver { get; set; }
        public string Description { get; set; }
        public string? ResolutionComment { get; set; }
        public bool Escalated { get; set; } = false;    //May not be implemented if there is no "upper" help desk
        public bool Resolved { get; set; } = false;
        public DateTime TimeSubmitted { get; set; }
        public DateTime? TimeResolved { get; set; }

    }
}
