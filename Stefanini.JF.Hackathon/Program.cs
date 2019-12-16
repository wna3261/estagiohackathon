using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Stefanini.JF.Hackathon.Services;

namespace Stefanini.JF.Hackathon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcao = -1;
            List<Candidato> candidatos = new List<Candidato>();
            uint numeroDeVagas = 0;
            while (opcao != 0)
            {
                ImprimirMenu();
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            {
                                candidatos.Add(CandidatoService.CadastrarNotaCandidato());
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
                            CandidatoService.GerarCandidatosAleatoriamente(candidatos);
                            break;
                        case 3:
                            bool success = false;
                            while (!success)
                            {
                                Console.WriteLine("Digite o numero de vagas:");
                                success = uint.TryParse(Console.ReadLine(), out numeroDeVagas);
                            }
                            Console.WriteLine($"NUMERO DE VAGAS: {numeroDeVagas}");
                            Console.ReadKey();
                            break;
                        case 4:
                            CandidatoService.ListarCandidatos(candidatos, numeroDeVagas);
                            break;
                    }
                }
                else
                {
                    opcao = -1;
                    Console.Write("Erro - É preciso digitar um numero inteiro. Pressione qualquer tecla para continuar");
                    Console.ReadLine();
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
            var builder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
