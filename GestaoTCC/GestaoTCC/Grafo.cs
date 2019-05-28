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
            foreach (var prof in Program.listProf)
            {
                Grupo group = new Grupo(prof);
                foreach (var aluno in Program.listAlunos)
                {
                    //implementar add de acordo com a matriz dissimilaridade
                    //implementar algoritmo de prim
                    group.Integrantes.Add(aluno);
                }
                //Program.gruposTCC.Add(group);
            }
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

            Aluno aluno = this.getMostClustering();
            Grupo grupo = new Grupo();

            aluno.IsAlocated = true;
            grupo.Integrantes.Add(aluno);

            foreach (var integrante in Program.listAlunos)
            {
                foreach (var pesquisa in Program.listPesq)
                {
                    if (pesquisa.Similaridade[integrante.Cod_pesq].Equals(0) && !integrante.IsAlocated)
                    {
                        integrante.IsAlocated = true;
                        grupo.Integrantes.Add(integrante);
                    }
                }
            }
            Program.listGrupos.Add(grupo);

            foreach (var classmate in Program.listAlunos)
            {
                if (!classmate.IsAlocated)
                {
                    //this.IsFull = false;
                    this.buildGroups();
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
    }
}
