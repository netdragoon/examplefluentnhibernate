using System;

namespace Models
{
    public class Itens
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Teste { get; set; }
        public virtual DateTime Data { get; set; }
    }
}
