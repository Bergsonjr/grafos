using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTCC
{
    class Grupo
    {
        Professor orientador;
        List<Aluno> integrantes;

        public Professor Orientador { get => orientador; set => orientador = value; }
        public List<Aluno> Integrantes { get => integrantes; set => integrantes = value; }

        public Grupo(Professor orientador, List<Aluno> alunos)
        {
            this.orientador = orientador;
            this.integrantes = alunos;
        }

        public Grupo(Professor orientador)
        {
            this.orientador = orientador;
        }

        public Grupo() {
            this.integrantes = new List<Aluno>();
        }

        public void ImprimeGrupo()
        {
            foreach (var grupo in Program.listGrupos)
            {
                Console.WriteLine(" Orientador: \n" + grupo.Orientador.Nome);
                Console.WriteLine("\n Alunos: ");
                foreach (var aluno in grupo.Integrantes)
                {
                    Console.WriteLine(aluno.Nome);
                }
            }
            Console.WriteLine("\n -----------------");
        }
    }
}
