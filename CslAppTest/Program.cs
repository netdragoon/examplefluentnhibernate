using Repositories.Interfaces;
using Repositories;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnection Connection = new Connection();
            var itens = Connection.SqlQuery("select id, nome FROM Itens");
            
        }
    }
}
