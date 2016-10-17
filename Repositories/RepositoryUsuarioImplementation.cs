using Models;
using Repositories.Abstract;
using Repositories.Interfaces;

namespace Repositories
{
    public abstract class RepositoryUsuarioImplementation :
        RepositoryImpl<Usuario>,
        ICrud<Usuario>
    {
        public RepositoryUsuarioImplementation(IConnection connection)
            :base(connection)
        {          
        }
    }
}
