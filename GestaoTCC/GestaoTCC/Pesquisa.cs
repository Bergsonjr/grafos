using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTCC
{
    class Pesquisa
    {
        int cod_pesq;
        string [] similar;

        public Pesquisa(int cod, string[] areas)
        {
            this.cod_pesq = cod;
            this.similar = areas;
        }
    }
}
