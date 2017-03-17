using System.Collections.Generic;
using System.Web.Http;
using WebForms.Services;
using WebFormsProject.Data;

namespace WebApiWebForms.Controllers
{
    public class UsuariosController : ApiController
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;
        public UsuariosController(IUsuarioService usuarioService, IProdutoService produtoService)
        {
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }
        public UsuariosController() { }

        // GET: api/Usuarios
        public IEnumerable<Produto> Get()
        {           
            return _produtoService.BuscarTodosProduto();
        }

        // GET: api/Usuarios/5
        public Produto Get(int id)
        {
            var lista = _produtoService.BuscarTodosProduto();
            var r = _usuarioService.RetornarMensagem();
            return _produtoService.GetByIdProduto(id); // _usuarioService.RetornarMensagem();
        }

        // POST: api/Usuarios
        [HttpPost]
        public void Post(Produto produto)
        {
            var p = new Produto() { Nome = "Jose mari" };
            _produtoService.CriarProduto(p);            
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
