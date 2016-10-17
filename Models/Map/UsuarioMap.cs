using FluentNHibernate.Mapping;

namespace Models.Map
{
    public class UsuarioMap: ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id(x => x.id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            Map(x => x.email)
                .Unique()
                .Not.Nullable()
                .Length(50);

            Map(x => x.nome)
                .Length(50)
                .Not.Nullable();

            Map(x => x.senha)
                .Length(50)
                .Not.Nullable();

            Map(x => x.status)
                .Not.Nullable();
                
        }
    }
}
