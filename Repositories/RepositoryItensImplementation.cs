using Models;
using Repositories.Abstract;
using Repositories.Interfaces;

namespace Repositories
{
    public class RepositoryItensImplementation :
        RepositoryImpl<Itens>,
        ICrud<Itens>
    {
        public RepositoryItensImplementation(IConnection connection) : 
            base(connection)
        {
        }
    }
}