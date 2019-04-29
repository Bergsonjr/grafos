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
        public static Pesquisa[] arrayPesq;
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
                int length = getFileLength(path), pos=0;
                arrayPesq = new Pesquisa[length];
                StreamReader file = new StreamReader(path);
                string linha = file.ReadLine();
                string[] separador;
                while (linha != null)
                {
                    separador = linha.Split(' ');
                    for (int i = 0; i < separador.Length; i++)
                    {
                        Console.Write(separador[i]);
                        /*Pesquisa pesquisa = null;
                        if(separador[i] != " ")
                        {
                            pesquisa = new Pesquisa(i, separador);   
                        }
                        Console.Write(separador[i] + " ");
                        arrayPesq[pos] = pesquisa;*/
                    }
                    Console.Write("\n");
                    //Console.Write(arrayPesq[pos]);
                    linha = file.ReadLine();
                    pos++;
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
    }
}