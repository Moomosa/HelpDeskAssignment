using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HelpDeskModelProject
{
    public class User
    {
        public User()
        {
            TicketList = new List<Tickets>();
        }

        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }
        [IgnoreDataMember]
        public List<Tickets> TicketList { get; set; }

    }
}