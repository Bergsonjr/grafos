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
        List<int> similaridade;

        public int Cod_pesq { get => cod_pesq; set => cod_pesq = value; }
        public string[] Similar { get => similar; set => similar = value; }
        public List<int> Similaridade { get => similaridade; set => similaridade = value; }

        public Pesquisa(int cod, string[] areas)
        {
            this.cod_pesq = cod;
            this.similar = areas;
        }

        public Pesquisa() { }

        public void setSimilaridade()
        {
            foreach (var pesquisa in Program.listPesq)
            {
                for (int i = 0; i < Program.listPesq.Count; i++)
                {
                    if(i == 0)
                    {
                        pesquisa.Similaridade.Add(pesquisa.Cod_pesq);
                    }
                    else
                    {
                        var item = Program.listPesq.Last();
                        int value = item.Similaridade[pesquisa.Cod_pesq];
                        pesquisa.Similaridade.Add(value);
                    }
                }
            }
        }
    }
}
