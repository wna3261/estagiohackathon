using System;
using System.Collections.Generic;
using System.Text;

namespace Stefanini.JF.Hackathon
{
    public class Candidato
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public double Nota { get; set; }
        public bool Aprovado { get; set; }

        public Candidato() { }

        public Candidato(string Nome, string Cidade, double Nota)
        {
            this.Nome = Nome;
            this.Cidade = Cidade;
            this.Nota = Nota;
        }
    }
}
