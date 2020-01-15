using System.Collections.Generic;
using System.Linq;
using Hackathon_API.Data.Repositories;
using Hackathon_API.Models;

namespace Hackathon_API.Services
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public IEnumerable<Candidato> GetCandidatos()
        {
            var candidatos = _candidatoRepository.GetCandidatos().OrderByDescending(x => x.Nota).ToList();
            return candidatos;
        }

        public Candidato PostCandidato(Candidato candidato)
        {
            if (candidato != null)
            {
                //candidato.Nota >= 0 && candidato.Nota <= 100 &&
                //&& !(string.IsNullOrWhiteSpace(candidato.Nome) || string.IsNullOrWhiteSpace(candidato.Cidade))
                //&& (candidato.Nome.All(char.IsLetter) || candidato.Nome.Any(char.IsWhiteSpace))
                //&& (candidato.Cidade.All(char.IsLetter) || candidato.Cidade.Any(char.IsWhiteSpace))
                if (candidato.Nota >= 0 && candidato.Nota <= 100 && !candidato.Nome.Contains("  ") && !candidato.Cidade.Contains("  "))
                {
                    var candidatoDb = _candidatoRepository.PostCandidato(candidato);

                    return candidatoDb;
                }
            }
            return null;
        }

        public Candidato GetCandidato(int idCandidato)
        {
            var candidato = _candidatoRepository.GetCandidato(idCandidato);

            return candidato;
        }

        public void DeleteCandidato(int idCandidato)
        {
            _candidatoRepository.DeleteCandidato(idCandidato);
        }

        public bool PutCandidato(Candidato candidato)
        {
            if (candidato == null) return false;
            if (candidato.Nota >= 0 && candidato.Nota <= 100 && !candidato.Nome.Contains("  ") && !candidato.Cidade.Contains("  "))
            {
                _candidatoRepository.PutCandidato(candidato);
                return true;
            }

            return false;
        }

        private void PutCandidatos(IEnumerable<Candidato> candidatos)
        {
            _candidatoRepository.PutCandidatos(candidatos);
        }

        public void ExibirResultados(int numVagas)
        {
            var candidatos = GetCandidatos().OrderByDescending(x => x.Nota).ToList();
            foreach (var candidato in candidatos)
            {
                if (candidato.Nota > 0 && numVagas > 0)
                {
                    candidato.Situacao = true;
                    numVagas--;
                }
                else if (numVagas == 0 || candidato.Nota.Equals(0.0))
                {
                    candidato.Situacao = false;
                }
            }
            PutCandidatos(candidatos);
        }
    }
}