using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskAssignment.Data;
using HelpDeskModelProject;
using HelpDeskAssignment.DTOObjects;

namespace HelpDeskAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly HelpDeskAssignmentContext _context;

        public TicketsController(HelpDeskAssignmentContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets(int skip, int take)
        {
            var tickets = await _context.Tickets
                    .Include(t => t.TicketSubmitter)
                    .Include(t => t.TicketResolver)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

            var totalTickets = tickets.Count;
            tickets = tickets.ToList();
            return Ok(new { totalTickets, tickets });
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTotalTicketCount()
        {
            //Get the count of all tickets in the db
            return await _context.Tickets.CountAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tickets>> GetTickets(int id)
        {
            //Gets the singular ticket based on the ticket id
            var tickets = await _context.Tickets.Include(t => t.TicketSubmitter).FirstOrDefaultAsync(t => t.TicketID == id);

            if (tickets == null)
                return NotFound();

            return tickets;
        }

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tickets>> PostTicket(Tickets tickets)
        {
            var tmp = _context.User.Where(x => x.ID == tickets.TicketSubmitterID).FirstOrDefault();
            Tickets tick = new Tickets()
            {
                TicketSubmitter = tmp,
                Description = tickets.Description,
                TicketSubmitterID = tmp.ID,
                TimeSubmitted = DateTime.Now
            };

            tmp.TicketList.Add(tick);
            _context.Tickets.Add(tick);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTickets", new { id = tick.TicketID }, tickets);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets(int id)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }

        //PUT: api/Tickets
        [HttpPut]
        public async Task<IActionResult> PutTicketsX(Tickets ticket)
        {
            var user = _context.User.SingleOrDefault(x => x.ID == ticket.TicketResolverID);
            if (user != null)
            {
                ticket.TicketResolver = (User)user;
                _context.Entry(ticket).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NoContent();
        }
    }
}
