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
        public List<RealServer> GetRealServers { get; set; }
        public List<Ticket> GetTheTickets { get; set; }

        public TicketsController(PaymentDetailContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            GetProducts = _context.Products.ToList();
            GetRealServers = _context.Servers.ToList();
            GetTheTickets = _context.Tickets.ToList();
            
            
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
            OnGet();
            var myTicket = GetTheTickets.Find(x => x.order_ID == ticket.order_ID);
            myTicket.deposit = ticket.deposit;
            myTicket.tip = ticket.tip;

                var tip = myTicket.tip;
                var deposit = myTicket.deposit;
                var total = myTicket.order_Total;

                if (deposit > total)
                {
                    var incrementedTip = deposit - total;
                    tip = tip + incrementedTip;
                }

                await _context.SaveChangesAsync();
            var a = GetRealServers.Find(x => x.server_ID == myTicket.server_ID);
                var a1 =  GetRealServers.Find(x => x.server_ID == myTicket.server_ID).total_TIPS + tip;

            _context.Servers.Add(a);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTicket", new { id = ticket.order_ID }, ticket);
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
            if (ticket.order_Name == null)
            {
                var value = GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_COST;
                GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_COUNT = GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_COUNT - 1;
                ticket.order_Total = value;
                int quantity = ticket.order_QTY;
                ticket.order_Total = ticket.order_Total * quantity;


                var nameValue = GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_NAME;
                ticket.order_Name = nameValue;
            }
            else
            {
                var value = GetProducts.Find(item => item.prod_NAME == ticket.order_Name).prod_COST;
                ticket.order_Total = value;
                int quantity = ticket.order_QTY;
                ticket.order_Total = ticket.order_Total * quantity;

                var nameValue = GetProducts.Find(item => item.prod_NAME == ticket.order_Name).prod_ID;
                ticket.prod_ID = nameValue;
                GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_COUNT = GetProducts.Find(item => item.prod_ID == ticket.prod_ID).prod_COUNT - quantity;
            }

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