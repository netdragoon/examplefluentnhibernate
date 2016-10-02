using Repositories.Interfaces;

namespace Repositories
{
    public sealed class RepositoryItens : RepositoryItensImplementation
    {
        public RepositoryItens(IConnection connection) : 
            base(connection)
        {
        }
    }
}
