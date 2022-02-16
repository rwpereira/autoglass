using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoGlass.Data;

namespace AutoGlass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            //            return await _context.Produtos.ToListAsync();
            return await _context.Produtos.Where(p => p.Situacao == "A").ToListAsync();
        }



        // GET: api/Produtos/5
        [HttpGet("{Codigo}")]
        public async Task<ActionResult<Produto>> GetProduto(int Codigo)
        {
            var produto = await _context.Produtos.FindAsync(Codigo);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }



        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> PutProduto(int Codigo, Produto produto)
        {
            if (Codigo != produto.Codigo)
            {
                return BadRequest();
            }

            if (produto.DataFabricacao > produto.DataValidade)
            {
                return BadRequest("Data de fabricação não pode ser maior que data de validade");
            }

            if (produto.Situacao != "A" && produto.Situacao != "I")
            {
                return BadRequest("A situação do Produto deve ser A para Ativo ou I para Inativo");
            }


            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Codigo))
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

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            if (produto.DataFabricacao > produto.DataValidade)
            {
                return BadRequest("Data de fabricação não pode ser maior que data de validade");
            }

            if (produto.Situacao != "A" && produto.Situacao != "I")
            {
                return BadRequest("A situação do Produto deve ser A para Ativo ou I para Inativo");
            }

     
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { Codigo = produto.Codigo }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{Codigo}")]
        public async Task<IActionResult> DeleteProduto(int Codigo)
        {
            var produto = await _context.Produtos.FindAsync(Codigo);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Situacao = "I";
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int Codigo)
        {
            return _context.Produtos.Any(e => e.Codigo == Codigo);
        }
    }
}
