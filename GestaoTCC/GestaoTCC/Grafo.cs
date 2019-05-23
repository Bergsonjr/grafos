using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTCC
{
    class Grafo
    {
        int totalConnections;

        public int TotalConnections { get => totalConnections; set => totalConnections = value; }

        public Grafo() { }
        //implementar algoritmos aqui
        public void setTuplas()
        {
            foreach (var prof in Program.listProf)
            {
                Grupo group = new Grupo(prof);
                foreach (var aluno in Program.listAlunos)
                {
                    //implementar add de acordo com a matriz dissimilaridade
                    //implementar algoritmo de prim
                    group.Integrantes.Add(aluno);
                }
                Program.gruposTCC.Add(group);
            }
        }

        public void setClusters()
        {
            foreach (var aluno in Program.listAlunos)
            {
                foreach (var pesq in Program.listPesq)
                {
                    if (pesq.Cod_pesq == aluno.Cod_pesq)
                    {
                        //calcular o indice de clusterização
                    }
                }
            }
        }

        public void setTotalConnections()
        {
            TotalConnections = (Program.K * (Program.K - 1))/ 2; // máximo de conexões possíveis entre alunos
        }
    }
}
