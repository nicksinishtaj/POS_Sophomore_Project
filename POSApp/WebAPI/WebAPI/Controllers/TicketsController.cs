using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketDetailContext _context;

        public TicketsController(TicketDetailContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDetail>>> GetTickets()
        {
            return await _context.TicketDetails.ToListAsync();
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, TicketDetail ticket)
        {
            if (id != ticket.order_ID)
            {
                return BadRequest();
            }
            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDetail>> GetTicket(int id)
        {
            var paymentDetail = await _context.TicketDetails.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> PostTicket(TicketDetail ticket)
        {

            _context.TicketDetails.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.order_ID }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketDetail>> DeleteTicket(int id)
        {

            var ticket = await _context.TicketDetails.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.TicketDetails.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        private bool TicketExists(int id)
        {
            return _context.TicketDetails.Any(e => e.order_ID == id);
        }
    }
}