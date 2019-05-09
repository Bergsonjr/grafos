using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTCC
{
    class Professor
    {
        string nome;

        public string Nome { get => nome; set => nome = value; }

        public Professor(string name)
        {
            this.nome = name;
        }
    }
}
