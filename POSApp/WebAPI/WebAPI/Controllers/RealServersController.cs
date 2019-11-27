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
    public class RealServersController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public RealServersController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/RealServers
        [HttpGet]
        public IEnumerable<RealServer> GetServers()
        {
            return _context.Servers;
        }

        // GET: api/RealServers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealServer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var realServer = await _context.Servers.FindAsync(id);

            if (realServer == null)
            {
                return NotFound();
            }

            return Ok(realServer);
        }

        // PUT: api/RealServers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealServer([FromRoute] int id, [FromBody] RealServer realServer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realServer.server_ID)
            {
                return BadRequest();
            }

            _context.Entry(realServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealServerExists(id))
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

        // POST: api/RealServers
        [HttpPost]
        public async Task<IActionResult> PostRealServer([FromBody] RealServer realServer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Servers.Add(realServer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealServer", new { id = realServer.server_ID }, realServer);
        }

        // DELETE: api/RealServers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealServer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var realServer = await _context.Servers.FindAsync(id);
            if (realServer == null)
            {
                return NotFound();
            }

            _context.Servers.Remove(realServer);
            await _context.SaveChangesAsync();

            return Ok(realServer);
        }

        private bool RealServerExists(int id)
        {
            return _context.Servers.Any(e => e.server_ID == id);
        }
    }
}