﻿using System;
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
        string nome;

        public int Cod_aluno { get => cod_aluno; set => cod_aluno = value; }
        public int Cod_pesq { get => cod_pesq; set => cod_pesq = value; }
        public string Nome { get => nome; set => nome = value; }

        public Aluno(int cod, int pesq, string name)
        {
            this.cod_aluno = cod;
            this.cod_pesq = pesq;
            this.nome = name;
        }
    }
}
