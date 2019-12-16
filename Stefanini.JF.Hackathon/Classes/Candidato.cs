using System;
using System.Collections.Generic;
using System.Text;
using Stefanini.JF.Hackathon.Classes;

namespace Stefanini.JF.Hackathon
{
    public class Candidato : Pessoa
    {
        
        public double Nota { get; set; }
        public bool Aprovado { get; set; }

        public Candidato() { }

        public Candidato(string Nome, string Cidade, double Nota)
        {
            this.Nome = Nome;
            this.Cidade = Cidade;
            this.Nota = Nota;
            this.Aprovado = false;
        }
    }
}
