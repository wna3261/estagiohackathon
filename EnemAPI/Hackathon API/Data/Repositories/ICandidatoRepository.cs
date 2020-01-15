using System.Collections.Generic;
using Hackathon_API.Models;

namespace Hackathon_API.Data.Repositories
{
    public interface ICandidatoRepository
    {
        IEnumerable<Candidato> GetCandidatos();
        Candidato PostCandidato(Candidato candidato);
        Candidato GetCandidato(int idCandidato);
        void DeleteCandidato(int idCandidato);
        void PutCandidato(Candidato candidato);
        void PutCandidatos(IEnumerable<Candidato> candidatos);
    }
}