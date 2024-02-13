using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagueMenosDesafio.Models;

namespace PagueMenosDesafio.Services
{
    public class ProdutoService
    {
        private readonly PagueMenosContext _context;

        public ProdutoService(PagueMenosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorLojaId(int lojaId)
        {
            return await _context.Produtos.Where(p => p.LojaId == lojaId).ToListAsync();
        }

        public async Task CriarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
