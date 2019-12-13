using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Stefanini.JF.Hackathon.Services
{
    public static class CandidatoService
    {
        public static void GerarCandidatosAleatoriamente(List<Candidato> candidatos)
        {
            var success = false;
            var cidades = new List<string>();
            Console.WriteLine("Digite o numero de cidades existentes:");
            Int32.TryParse(Console.ReadLine(), out var numCidades);
            for (int i = 0; i < numCidades; i++)
            {
                cidades.Add(Program.RandomString(5, false));
            }
            while (!success)
            {
                Console.WriteLine("Quantos candidatos voce deseja gerar?");
                success = Int32.TryParse(Console.ReadLine(), out var numCandidatos);
                if (!success)
                    Console.WriteLine("Digite um numero inteiro");
                else
                {
                    for (int i = 0; i < numCandidatos; i++)
                    {
                        Random random = new Random();
                        var n = Program.RandomString(5, false);
                        var c = cidades[random.Next(0, numCidades)];
                        var nt = random.Next(100) * random.NextDouble();
                        nt = Math.Round(nt, 2);
                        var novoCandidato = new Candidato(n, c, nt);
                        candidatos.Add(novoCandidato);
                    }
                }
            }

            foreach (var candidato in candidatos)
            {
                Console.WriteLine($"NOME: {candidato.Nome}");

                Console.WriteLine(candidato.Cidade);
                Console.WriteLine(candidato.Nota);
            }

            Console.ReadKey();
        }

        public static Candidato CadastrarNotaCandidato()
        {
            string nome;
            string cidade;
            double nota = -1;
            string notaDigitada;
            do
            {
                Console.WriteLine("Digite o nome:");
                nome = Console.ReadLine();
            } while (nome.Any(char.IsDigit));

            do
            {
                Console.WriteLine("Digite a cidade:");
                cidade = Console.ReadLine();
            } while (cidade.Any(char.IsDigit));

            do
            {
                Console.WriteLine("Digite o nota:");
                notaDigitada = Console.ReadLine();
                double.TryParse(notaDigitada, out nota);
            } while ((nota < 0 || nota > 100) || !notaDigitada.Any(char.IsDigit));

            Candidato novo = new Candidato(nome, cidade, nota);
            return novo;
        }
    }
}
