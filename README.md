# HelpDeskAssignment

So this is a simple database system that stores Users and Tickets.

# Users
Users contain the following properties:

        public int ID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }        
        public List<Tickets> TicketList { get; set; }

I chose to have an int ID to uniquely identify the users. This decision was made so that in a large setting, there could be multiple users with the same username, but in my implementation this was lost as you select your username when making/resolving tickets.
Currently, TicketList doesn't exist in the database. There is a moment when saving a new ticket to the database that the ticket is stored in the list, but that list isn't stored anywhere, just in current memory while the program is live.

# Tickets
Tickets contain the following properties:

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

Again I chose an int ID as the PK to keep things simple. I imagine in a larger setting this would get impractical and would need more sophistication. I set an ID for both the submitter and resolver user to syncronize well with the user class so I could just grab the id number to reference the user instead of the entire class. 
I kept a bool for resolved to allow for searches if it had been resolved, while the escalated bool was not implemented. In a larger setting with multiple layers of personnel the escalated bool could be a good reference tool to check if a resolver had a higher rate of escalation than others.
