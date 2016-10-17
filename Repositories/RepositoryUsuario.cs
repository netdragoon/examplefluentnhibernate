using Repositories.Interfaces;

namespace Repositories
{
    public sealed class RepositoryUsuario: RepositoryUsuarioImplementation
    {
        public RepositoryUsuario(IConnection connection)
            :base(connection)
        {

        }
    }
}
