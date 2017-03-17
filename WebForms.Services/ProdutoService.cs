using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsProject.Data;
using WebFormsProject.Data.Repository;

namespace WebForms.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> BuscarTodosProduto();
    }
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public IEnumerable<Produto> BuscarTodosProduto()
        {
            return _produtoRepository.GetAll();
        }
    }
}
