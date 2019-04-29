using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTCC
{
    class Aluno
    {
        int cod_aluno;
        int cod_pesq;

        public Aluno(int cod, int pesq)
        {
            this.cod_aluno = cod;
            this.cod_pesq = pesq;
        }

        public int Cod_aluno { get => cod_aluno; set => cod_aluno = value; }
        public int Cod_pesq { get => cod_pesq; set => cod_pesq = value; }
    }
}
