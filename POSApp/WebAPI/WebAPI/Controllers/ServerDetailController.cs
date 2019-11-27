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
    public class ServerDetailController : ControllerBase
    {
        private readonly ServerDetailContext _context;

        public ServerDetailController(ServerDetailContext context)
        {
            _context = context;
        }

        // GET: api/ServerDetail
        [HttpGet]
        public IEnumerable<Server> GetServerDetails()
        {
            return _context.ServerDetails;
        }

        // GET: api/ServerDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var server = await _context.ServerDetails.FindAsync(id);

            if (server == null)
            {
                return NotFound();
            }

            return Ok(server);
        }

        // PUT: api/ServerDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServer([FromRoute] int id, [FromBody] Server server)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != server.PMId)
            {
                return BadRequest();
            }

            _context.Entry(server).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServerExists(id))
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

        // POST: api/ServerDetail
        [HttpPost]
        public async Task<IActionResult> PostServer([FromBody] Server server)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServerDetails.Add(server);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServer", new { id = server.PMId }, server);
        }

        // DELETE: api/ServerDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var server = await _context.ServerDetails.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }

            _context.ServerDetails.Remove(server);
            await _context.SaveChangesAsync();

            return Ok(server);
        }

        private bool ServerExists(int id)
        {
            return _context.ServerDetails.Any(e => e.PMId == id);
        }
    }
}