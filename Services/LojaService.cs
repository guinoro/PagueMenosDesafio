using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagueMenosDesafio.Models;

namespace PagueMenosDesafio.Services
{
    public class LojaService
    {
        private readonly PagueMenosContext _context;

        public LojaService(PagueMenosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loja>> ObterTodasLojas()
        {
            return await _context.Lojas.ToListAsync();
        }

        public async Task<Loja> ObterLojaPorId(int id)
        {
            return await _context.Lojas.FindAsync(id);
        }

        public async Task CriarLoja(Loja loja)
        {
            _context.Lojas.Add(loja);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarLoja(Loja loja)
        {
            _context.Entry(loja).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirLoja(int id)
        {
            var loja = await _context.Lojas.FindAsync(id);
            _context.Lojas.Remove(loja);
            await _context.SaveChangesAsync();
        }
    }
}
