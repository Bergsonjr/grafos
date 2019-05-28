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
        public List<int> Similaridade { get { return similaridade; } set => similaridade = value; }

        public Pesquisa(int cod, string[] areas)
        {
            this.cod_pesq = cod;
            this.similar = areas;
            this.similaridade = new List<int>();
        }

        public Pesquisa() {  }

        public void setSimilaridade()
        {
            foreach (var pesquisa in Program.listPesq)
            {
                if (pesquisa.Cod_pesq == 1)
                {
                    for (int j = 0; j < pesquisa.Similar.Length; j++)
                    {
                        pesquisa.Similaridade.Add(int.Parse(pesquisa.similar[j]));
                    }
                }
                else
                {
                    //adiciona a similaridade de todos anteriores
                    for (int i = 1; i < pesquisa.Cod_pesq; i++)
                    {
                        var item = Program.listPesq[i - 1]; //pega o anterior na lista
                        int value = int.Parse(item.similar[pesquisa.Cod_pesq - i]); //procura no anterior o valor de sua similaridade
                        pesquisa.Similaridade.Add(value); //adiciona o valor da similaridade na sua lista
                    }
                    
                    //preenche a lista com os valores já lidos do arquivo
                    for (int k = 0; k < pesquisa.Similar.Length; k++)
                    {
                        pesquisa.Similaridade.Add(int.Parse(pesquisa.similar[k]));
                    }
                }
            }
        }
    }
}
