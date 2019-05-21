using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTCC
{
    class Grafo
    {
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
    }
}
