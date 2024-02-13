using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagueMenosDesafio.Models;

namespace PagueMenosDesafio.Services
{
    public class PrecoService
    {
        private readonly PagueMenosContext _context;

        public PrecoService(PagueMenosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Preco>> ObterTodosPrecos()
        {
            return await _context.Precos.ToListAsync();
        }

        public async Task<Preco> ObterPrecoPorId(int id)
        {
            return await _context.Precos.FindAsync(id);
        }

        public async Task<Preco> ObterPrecoPorProdutoId(int produtoId)
        {
            return await _context.Precos.Where(p => p.ProdutoId == produtoId).FirstOrDefaultAsync();
        }

        public async Task CriarPreco(Preco preco)
        {
            _context.Precos.Add(preco);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarPreco(Preco preco)
        {
            _context.Entry(preco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirPreco(int id)
        {
            var preco = await _context.Precos.FindAsync(id);
            _context.Precos.Remove(preco);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> PrecoExiste(int produtoId)
        {
            return await _context.Precos.AnyAsync(p => p.ProdutoId == produtoId);
        }
    }
}
