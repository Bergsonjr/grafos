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
        bool isFull;

        public int TotalConnections { get => totalConnections; set => totalConnections = value; }
        public bool IsFull { get => isFull; set => isFull = value; }

        public Grafo() { }
        //implementar algoritmos aqui
        public void setTuplas()
        {
            
        }

        public void setClusters()
        {
            double value = 0;
            this.setTotalConnections();
            foreach (var aluno in Program.listAlunos)
            {
                foreach (var pesq in Program.listPesq)
                {
                    if (pesq.Cod_pesq == aluno.Cod_pesq)
                    {
                        //calcular o indice de clusterização
                        foreach (var val in pesq.Similaridade)
                        {
                            if (val > -1 && val < 1)
                            {
                                value++;
                            }
                        }
                        aluno.Cluster = (double)(value / this.TotalConnections);
                        value = 0;
                    }
                }
            }
            this.buildGroups();
        }

        public void setTotalConnections()
        {
            TotalConnections = (Program.K * (Program.K - 1))/ 2; // máximo de conexões possíveis entre alunos
        }

        public void buildGroups()
        {
            //pontos importantes//

            /*
             * O número de grupos deve ser igual ao número de professores
             * Caso nao tenha similaridade = 0, alocar para o que tiver maior aproximação
             * Implementar ideia de tuplas
             */

            this.setHeadGroups();

            for (int i = 0; i < Program.listGrupos.Count; i++)
            {
                foreach (var aluno in Program.listAlunos)
                {
                    if (!aluno.IsAlocated && Program.listPesq[aluno.Cod_pesq - 1].Similaridade[Program.listGrupos[i].Integrantes[0].Cod_pesq - 1].Equals(0))
                    {
                        aluno.IsAlocated = true;
                        Program.listGrupos[i].Integrantes.Add(aluno);
                    }
                }
            }
        }

        public Aluno getMostClustering()
        {
            Aluno bigCluster = null;
            double value = double.MinValue;

            foreach (var aluno in Program.listAlunos)
            {
                if(aluno.Cluster > value && !aluno.IsAlocated)
                {
                    bigCluster = aluno;
                    value = aluno.Cluster;
                }
            }
            return bigCluster;
        }

        public void setHeadGroups()
        {
            int i = 0;
            //setar os principais do grupo de acordo com a quantidade de professores
            while (Program.listGrupos.Count < Program.listProf.Count)
            {
                Aluno head = this.getMostClustering();
                Grupo grupo = new Grupo();

                head.IsAlocated = true;
                grupo.Orientador = Program.listProf[i];
                grupo.Integrantes.Add(head);

                Program.listGrupos.Add(grupo);
                i++;
            }
        }
    }
}
