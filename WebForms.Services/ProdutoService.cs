using System;
using System.Collections.Generic;
using WebFormsProject.Data;
using WebFormsProject.Data.Infrastructure;
using WebFormsProject.Data.Repository;

namespace WebForms.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> BuscarTodosProduto();
        Produto GetByIdProduto(int id);
        void CriarProduto(Produto p);
    }
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Produto> BuscarTodosProduto()
        {
            return  _produtoRepository.GetAll();
        }

        public void CriarProduto(Produto p)
        {
            _produtoRepository.Add(p);
            SaveChanges();
        }

        public Produto GetByIdProduto(int id)
        {
           return _produtoRepository.GetById(id);
        }
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
