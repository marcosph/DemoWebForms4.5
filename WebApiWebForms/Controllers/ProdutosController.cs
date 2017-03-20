using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebFormsProject.Data;

namespace WebApiWebForms.Controllers
{
    public class ProdutosController : ApiController
    {
        private DX3Context db = new DX3Context();

        // GET: api/Produtos
        public IQueryable<Produto> GetProduto()
        {
            return db.Produto;
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produto))]
        [Route("api/produtos/{id}/{nome}")]
        public IEnumerable<Produto> GetProduto(int id, string nome)
        {
           // Produto produto = await db.Produto.FindAsync(id);
            var query = db.Produto.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.Nome.ToUpper().Contains(nome.ToUpper()));
            }

            //if (produto == null)
            //{
            //   // return NotFound();
            //}

            return query;
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.Id)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Produto))]
        public async Task<IHttpActionResult> PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produto.Add(produto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public async Task<IHttpActionResult> DeleteProduto(int id)
        {
            Produto produto = await db.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.Produto.Remove(produto);
            await db.SaveChangesAsync();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produto.Count(e => e.Id == id) > 0;
        }
    }
}