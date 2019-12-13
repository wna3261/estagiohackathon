using System;
using System.Threading;

namespace Stefanini.JF.Hackathon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                ImprimirMenu();

                bool PodeConverter = int.TryParse(Console.ReadLine(), out opcao);
                if (PodeConverter)
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
                            GerarCandidatosAleatoriamente();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um numero intiero.");
                }
            };
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

        public static void GerarCandidatosAleatoriamente() {
            bool Success = false;
            int NumCandidatos;
            while (!Success)
            {
                Console.WriteLine("Quantos candidatos voce deseja gerar?");
                Success = int.TryParse(Console.ReadLine(), out NumCandidatos);
                if (!Success)
                    Console.WriteLine("Digite um numero inteiro");
                else { 
                    for(int i = 0; i < NumCandidatos; i++)
                    {

                    }
                }
            }
            
        }
    }
}
