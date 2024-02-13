using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagueMenosDesafio.Models;

namespace PagueMenosDesafio.Services
{
    public class EstoqueService
    {
        private readonly PagueMenosContext _context;

        public EstoqueService(PagueMenosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estoque>> ObterTodosEstoques()
        {
            return await _context.Estoques.ToListAsync();
        }

        public async Task<Estoque> ObterEstoquePorId(int id)
        {
            return await _context.Estoques.FindAsync(id);
        }

        public async Task<Estoque> ObterEstoquePorProdutoId(int produtoId)
        {
            return await _context.Estoques.Where(e => e.ProdutoId == produtoId).FirstOrDefaultAsync();
        }

        public async Task CriarEstoque(Estoque estoque)
        {
            _context.Estoques.Add(estoque);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarEstoque(Estoque estoque)
        {
            _context.Entry(estoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirEstoque(int id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
        }
    }
}
