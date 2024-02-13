using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagueMenosDesafio.Models;

namespace PagueMenosDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecoController : ControllerBase
    {
        private readonly PagueMenosContext _context;

        public PrecoController(PagueMenosContext context)
        {
            _context = context;
        }

        // GET: api/Preco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preco>>> GetPrecos()
        {
            return await _context.Precos.ToListAsync();
        }

        // GET: api/Preco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preco>> GetPreco(int id)
        {
            var preco = await _context.Precos.FindAsync(id);

            if (preco == null)
            {
                return NotFound();
            }

            return preco;
        }

        // POST: api/Preco
        [HttpPost]
        public async Task<ActionResult<Preco>> PostPreco(Preco preco)
        {
            _context.Precos.Add(preco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreco), new { id = preco.Id }, preco);
        }

        // PUT: api/Preco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreco(int id, Preco preco)
        {
            if (id != preco.Id)
            {
                return BadRequest();
            }

            _context.Entry(preco).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Preco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreco(int id)
        {
            var preco = await _context.Precos.FindAsync(id);

            if (preco == null)
            {
                return NotFound();
            }

            _context.Precos.Remove(preco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
