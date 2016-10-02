using FluentNHibernate.Mapping;
namespace Models.Map
{
    public class ItensMap : ClassMap<Itens>
    {
        public ItensMap()
        {
            Table("Itens");

            Id(x => x.Id)
                .GeneratedBy
                .Identity();

            Map(x => x.Nome)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Teste)                
                .Default("teste")
                .Not.Nullable()
                .Length(50);

            Map(x => x.Data)
                .Default("GETDATE()")
                .Not.Nullable();                
        }
    }
}
