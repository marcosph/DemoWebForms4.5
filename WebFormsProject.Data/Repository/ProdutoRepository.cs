using WebFormsProject.Data.Infrastructure;

namespace WebFormsProject.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IProdutoRepository : IRepository<Produto>
    {
    }
}
