using System;
using System.Collections.Generic;
using System.Text;
using Stefanini.JF.Hackathon.Classes;
using Stefanini.JF.Hackathon.Interfaces;

namespace Stefanini.JF.Hackathon
{
    public class Candidato : Pessoa, IAtribuicaoId
    {
        private int Id { get; set; }
        public double Nota { get; set; }
        public bool Aprovado { get; set; }

        private static int _candidatosCriados = 0;
        public Candidato() { }

        public Candidato(string Nome, string Cidade, double Nota)
        {
            this.Nome = Nome;
            this.Cidade = Cidade;
            this.Nota = Nota;
            this.Aprovado = false;
            IncrementarId();
            _candidatosCriados++;
        }

        public void IncrementarId()
        {
            this.Id = _candidatosCriados;
        }
    }
}
