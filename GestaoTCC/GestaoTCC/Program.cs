using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace GestaoTCC
{
    class Program
    {
        public static List<Aluno> listAlunos = new List<Aluno>();
        public static List<Pesquisa> listPesq = new List<Pesquisa>();
        static void Main(string[] args)
        {
            Console.Clear();
            string pathAluno = "Dados_Aluno.txt";
            string pathMatriz = "Matriz_Dissimilaridade.txt";

            readFileAluno(pathAluno);
            readFileMatriz(pathMatriz);

            Console.ReadKey();
        }

        public static void readFileAluno(string path)
        {
            try
            {
                StreamReader file = new StreamReader(path);
                string linha = file.ReadLine();
                string[] separador;
            
                while (linha != null)
                {
                    
                    separador = linha.Split(' ');
                    listAlunos.Add(new Aluno(int.Parse(separador[0]), int.Parse(separador[1])));
                    linha = file.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.Write("Pressione enter para reiniciar");
            }
        }

        public static void readFileMatriz(string path)
        {
            try
            {
                StreamReader file = new StreamReader(path);
                string linha = file.ReadLine();
                string[] separador;
                string[] aux;
                while (linha != null)
                {
                    separador = linha.Split(' ');
                    for (int i = 0; i < separador.Length; i++)
                    {
                        Console.Write(separador[i] + " ");
                        /*aux = separador[i].Split(' ');
                        Console.WriteLine(aux[0] + "aux");*/
                        transformArray(separador);
                        listPesq.Add(new Pesquisa(listAlunos[i].Cod_pesq, separador));
                    }
                    Console.Write("\n");
                    //Console.Write(arrayPesq[pos]);
                    linha = file.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.Write("Pressione enter para reiniciar");
            }
            
        }

        public static int getFileLength(string path)
        {
            if (File.Exists(path)) {
                StreamReader file = new StreamReader(path);
                int count = 0;
                while (!file.EndOfStream)
                {
                    file.ReadLine();
                    count++;
                }
                return count;
            }
            else
            {
                throw new Exception();
            }
        }

        public static string[] transformArray(string[] array)
        {
            string []transform = new string[array.Length-1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0) transform[i - 1] = array[i];
                Console.WriteLine(array[i] + "transform");
            }
            return transform;
        }
    }
}