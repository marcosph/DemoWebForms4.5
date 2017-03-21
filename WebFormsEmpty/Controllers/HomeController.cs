using System.Linq;
using System.Web.Mvc;
using WebForms.Services;
using WebFormsProject.Data;

namespace WebFormsEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoService _produtoService;
        public HomeController(IProdutoService produtoService)
        {          
            _produtoService = produtoService;
        }
       // public HomeController() { }
        
        // GET: Home
        //[Route("home/{nome?}")]
        public ActionResult Index()
        {
            var p = new Produto() { Nome = "XXXXXXX" };
             _produtoService.CriarProduto(p);
            var r = _produtoService.BuscarTodosProduto().Where(o => o.Nome.Equals("XXXXXXX")).FirstOrDefault();
            return View();
        }
       
       // [Route("produtos/{nome?}/{id?}")]  
        //[HttpGet]
        public JsonResult Produtos(string nome, string id)
        {
            var p = _produtoService.BuscarTodosProduto();
            bool isAdmin = false;
            //TODO: Check the user if it is admin or normal user, (true-Admin, false- Normal user)  
            string output = isAdmin ? "Welcome to the Admin User" : "Welcome to the User";
            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}