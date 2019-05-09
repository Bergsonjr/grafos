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

        public int Cod_pesq { get => cod_pesq; set => cod_pesq = value; }
        public string[] Similar { get => similar; set => similar = value; }

        public Pesquisa(int cod, string[] areas)
        {
            this.cod_pesq = cod;
            this.similar = areas;
        }
    }
}
