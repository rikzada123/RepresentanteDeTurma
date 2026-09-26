using Microsoft.AspNetCore.Mvc;
using Turma.Models;
using Turma.Repositories;

namespace Turma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _repository;

        public CadastroController(ICadastroRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(DadosCadastro dados)
        {
            bool sucesso = _repository.CadastrarCandidato(dados);

            if (!sucesso)
                return BadRequest($"Candidato numero {dados.numeroCandidado} já cadastrado.");

            return Ok($"Aluno {dados.nome} cadastrado!");
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_repository.ListarCandidatos());
        }

        [HttpPost]
        [Route("Votar")]
        public IActionResult Votar(Voto dadosVoto)
        {
            bool sucesso = _repository.Votar(dadosVoto);

            if (!sucesso)
                return BadRequest($"Voto do aluno com RA {dadosVoto.ra} já existe.");

            return Ok($"Voto do aluno com o RA {dadosVoto.ra} confirmado.");
        }

        [HttpGet]
        [Route("ConsultarVotosPorCandidato/{numeroCandidato}")]
        public IActionResult ConsultarVotosPorCandidato(int numeroCandidato)
        {
            var votosDoCandidato = _repository.ConsultarVotosPorCandidato(numeroCandidato);
            return Ok(votosDoCandidato);
        }
    }
}