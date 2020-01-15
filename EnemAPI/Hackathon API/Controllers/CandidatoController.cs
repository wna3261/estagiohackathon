using System;
using Hackathon_API.Models;
using Hackathon_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_API.Controllers
{
    [ApiController]
    [Route("candidatos")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatosController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet]
        public IActionResult GetCandidatos()
        {
            try
            {
                return Ok(_candidatoService.GetCandidatos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{idCandidato}")]
        public IActionResult GetCandidato(int idCandidato)
        {
            try
            {
                var candidato = _candidatoService.GetCandidato(idCandidato);
                return Ok(candidato);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult PostCandidato([FromBody]Candidato candidato)
        {
            try
            {
                var result = _candidatoService.PostCandidato(candidato);
                if (result != null)
                {
                    return Created("/candidatos", result);
                }

                return BadRequest("Campos Nome e Cidade não permitem valores numéricos\n Nota deve estar entre 0 e 100");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult PutCandidato([FromBody]Candidato candidato)
        {
            try
            {
                var result = _candidatoService.PutCandidato(candidato);
                if (result)
                    return NoContent();

                return BadRequest("Campos Nome e Cidade não permitem valores numéricos\n Nota deve estar entre 0 e 100");

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{idCandidato}")]
        public IActionResult DeleteCandidato(int idCandidato)
        {
            try
            {
                _candidatoService.DeleteCandidato(idCandidato);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("exibirResultados/{numVagas}")]
        public IActionResult ExibirResultados(int numVagas)
        {
            try
            {
                _candidatoService.ExibirResultados(numVagas);
                return Ok(new { Success = true, Message = "Lista de Aprovados atualizado com sucesso!" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}