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
        private readonly PaymentDetailContext _context;
        public List<Product> GetProducts { get; set; }

        public TicketsController(PaymentDetailContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            GetProducts = _context.Products.ToList();
            
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.order_ID)
            {
                return BadRequest();
            }
            OnGet();
            var value = GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_COST;
            ticket.order_Total = (int)value;
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
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var paymentDetail = await _context.Tickets.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> PostTicket(Ticket ticket)
        {
            OnGet();
            var value = GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_COST;
            ticket.order_Total = value;

            var nameValue = GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_NAME;
            ticket.order_Name = nameValue;

            _context.Tickets.Add(ticket);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.order_ID }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.order_ID == id);
        }
    }
}