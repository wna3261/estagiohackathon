using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Stefanini.JF.Hackathon.Services
{
    public static class CandidatoService
    {
        public static void GerarCandidatosAleatoriamente(List<Candidato> candidatos)
        {
            var success = false;
            var cidades = new HashSet<string>();
            Random random = new Random();
            Console.WriteLine("Digite o numero de cidades existentes:");
            Int32.TryParse(Console.ReadLine(), out var numCidades);
            for (int i = 0; i < numCidades; i++)
            {
                cidades.Add(Program.RandomString(random.Next(1, 5), false));
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

                        var n = Program.RandomString(random.Next(1, 5), false);
                        var c = cidades.ElementAt(random.Next(0, numCidades));
                        var nt = random.Next(100) * random.NextDouble();
                        nt = Math.Round(nt, 2);
                        var novoCandidato = new Candidato(n, c, nt);
                        candidatos.Add(novoCandidato);
                    }
                }
            }

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
                Console.WriteLine("Digite uma nota com valor entre 0 e 100:");
                notaDigitada = Console.ReadLine();
                double.TryParse(notaDigitada, out nota);
            } while ((nota < 0 || nota > 100) || !notaDigitada.Any(char.IsDigit));

            Candidato novo = new Candidato(nome, cidade, nota);
            return novo;
        }

        public static void ListarCandidatos(List<Candidato> candidatos, uint numeroDeVagas)
        {
            candidatos = candidatos.OrderByDescending(o => o.Nota).ToList();
            int posicao = 1;
            for (int i = 0; i < numeroDeVagas; i++)
            {
                if (numeroDeVagas > candidatos.Count())
                {
                    foreach (var candidato in candidatos)
                    {
                        if (candidato.Nota > 0)
                            candidato.Aprovado = true;
                    }
                }
                else
                {
                    if (candidatos[i] != null && candidatos[i].Nota > 0)
                    {
                        candidatos[i].Aprovado = true;
                    }
                }
            }
            Console.WriteLine($"NUMERO DE VAGAS: {numeroDeVagas}");
            foreach (var candidato in candidatos)
            {
                var aprovado = candidato.Aprovado ? "APROVADO" : "REPROVADO";
                Console.WriteLine($"NOME: {candidato.Nome} \t CIDADE: {candidato.Cidade} \t NOTA: {candidato.Nota}" +
                                  $" \t {aprovado} \t COLOCAÇÃO: {posicao}");
                posicao++;
            }

            bool conseguiuConverter = false;
            bool gravar = false;
            int valor = -1;
            int posicao2 = 1;
            while (!conseguiuConverter)
            {
                Console.WriteLine("\nDESEJA QUE AS INFORMAÕES SEJAM GRAVADAS EM UM ARQUIVO TEXTO? 1-SIM 0-NAO");
                conseguiuConverter = int.TryParse(Console.ReadLine(), out valor);
                if (valor != 1 && valor != 0)
                {
                    conseguiuConverter = false;
                }
            }

            if (valor == 1)
            {
                gravar = true;
            }

            if (gravar)
            {
                var date = DateTime.Now.ToString("dd-MM-yy");
                var hour = DateTime.Now.ToString("HH-mm-ss");
                var nomeArquivo = "US03-date-" + date + "-hour-" + hour + ".txt";
                using (Stream arquivo = File.Open(nomeArquivo, FileMode.Create))
                using (StreamWriter escritor = new StreamWriter(arquivo))
                {
                    foreach (var candidato in candidatos)
                    {
                        var aprovado = candidato.Aprovado ? "APROVADO" : "REPROVADO";
                        escritor.WriteLine($"NOME: {candidato.Nome} \t CIDADE: {candidato.Cidade} \t NOTA: {candidato.Nota}" +
                                          $" \t {aprovado} \t COLOCAÇÃO: {posicao2}");
                        posicao2++;
                    }
                }
            }
            Console.WriteLine("PRESSIONE UMA TECLA PARA CONTINUAR");
            Console.ReadKey();
        }

        public static void ExibirPercentualCidade(List<Candidato> candidatos, uint numeroDeVagas)
        {
            candidatos = candidatos.OrderByDescending(o => o.Nota).ToList();
            List<Candidato> aprovados = new List<Candidato>();
            int numAprovados = 0;
            foreach (var candidato in candidatos)
            {
                if (numAprovados < numeroDeVagas && candidato.Nota > 0)
                {
                    candidato.Aprovado = true;
                    aprovados.Add(candidato);
                    numAprovados++;
                }
            }

            var candidatoCidade = aprovados.GroupBy(o => o.Cidade);
            Console.WriteLine($"QUANTIDADE DE APROVADOS: {aprovados.Count()}");

            foreach (var x in candidatoCidade)
            {
                var percentual = Math.Round((double)x.Count() / aprovados.Count(), 2);
                Console.WriteLine($"RELAÇÃO CIDADE: {x.Key} APROVADOS NA CIDADE: {x.Count()} PERCENTUAL: {(percentual) * 100}%");
            }
            bool conseguiuConverter = false;
            bool gravar = false;
            int valor = -1;
            while (!conseguiuConverter)
            {
                Console.WriteLine("\nDESEJA QUE AS INFORMAÕES SEJAM GRAVADAS EM UM ARQUIVO TEXTO? 1-SIM 0-NAO");
                conseguiuConverter = int.TryParse(Console.ReadLine(), out valor);
                if (valor != 1 && valor != 0)
                {
                    conseguiuConverter = false;
                }
            }

            if (valor == 1)
            {
                gravar = true;
            }

            if (gravar)
            {
                var date = DateTime.Now.ToString("dd-MM-yy");
                var hour = DateTime.Now.ToString("HH-mm-ss");
                var nomeArquivo = "US04-date-" + date + "-hour-" + hour + ".txt";
                using (Stream arquivo = File.Open(nomeArquivo, FileMode.Create))
                using (StreamWriter escritor = new StreamWriter(arquivo))
                {
                    foreach (var x in candidatoCidade)
                    {
                        var percentual = Math.Round((double) x.Count() / aprovados.Count(), 2);
                        escritor.WriteLine(
                            $"RELAÇÃO CIDADE: {x.Key} APROVADOS NA CIDADE: {x.Count()} PERCENTUAL: {(percentual) * 100}%");
                    }
                }
            }
            Console.WriteLine("PRESSIONE UMA TECLA PARA CONTINUAR");
            Console.ReadKey();
        }
    }
}
