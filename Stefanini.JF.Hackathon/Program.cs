using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Stefanini.JF.Hackathon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcao = -1;
            List<Candidato> candidatos = new List<Candidato>();
            while (opcao != 0)
            {
                ImprimirMenu();


                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            {
                                Console.WriteLine("Cadastrando candidato....");
                                Thread.Sleep(1000);
                                Console.WriteLine("Candidato cadastrado com sucesso!");
                                Thread.Sleep(1000);
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            GerarCandidatosAleatoriamente(candidatos);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um numero intiero.");
                }
            }
        }

        public static void ImprimirMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("0 - SAIR");
            Console.WriteLine("1 - CADASTRAR NOTA DO CANDIDATO");
            Console.WriteLine("2 - GERAR CANDIDATOS ALEATORIAMENTE");
            Console.WriteLine("3 - INSERIR NUMERO DE VAGAS");
            Console.WriteLine("4 - EXIBIR CANDIDATOS APROVADOS");
            Console.WriteLine("5 - EXIBIR PORCENTAGEM DE APROVADOS POR CIDADE");
            Console.WriteLine();
            Console.Write("ESCOLHA UMA OPÇÃO: ");
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static void GerarCandidatosAleatoriamente(List<Candidato> candidatos)
        {
            bool success = false;
            int numCandidatos;
            int numCidades;
            var cidades = new List<string>();
            Console.WriteLine("Digite o numero de cidades existentes:");
            numCidades = int.Parse(Console.ReadLine());
            for (int i = 0; i < numCidades; i++)
            {
                cidades.Add(RandomString(5, false));
            }
            while (!success)
            {
                Console.WriteLine("Quantos candidatos voce deseja gerar?");
                success = int.TryParse(Console.ReadLine(), out numCandidatos);
                if (!success)
                    Console.WriteLine("Digite um numero inteiro");
                else
                {
                    for (int i = 0; i < numCandidatos; i++)
                    {
                        Random random = new Random();
                        string n = RandomString(5, false);
                        string c = cidades[random.Next(0, numCidades)];
                        double nt = random.Next(100) * random.NextDouble();
                        nt = Math.Round(nt, 2);
                        var novoCandidato = new Candidato(n, c, nt);
                        candidatos.Add(novoCandidato);
                    }
                }
            }

            //foreach (var candidato in candidatos)
            //{
            //    Console.WriteLine(candidato.Nome);
            //    Console.WriteLine(candidato.Cidade);
            //    Console.WriteLine(candidato.Nota);
            //}

            //Console.ReadKey();
        }
    }
}
