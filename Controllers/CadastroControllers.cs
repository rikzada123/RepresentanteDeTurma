using Microsoft.AspNetCore.Mvc;
using Turma.Models;

namespace Turma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private static List<DadosCadastro> dadosCadastrosList = new List<DadosCadastro>();
        private static List<Voto> dadosVotoList = new List<Voto>();
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(DadosCadastro dados)
        {
            var alunoExiste = dadosCadastrosList.Where(a => a.numeroCandidado == dados.numeroCandidado).FirstOrDefault();

            if (alunoExiste is not null)
                return BadRequest($"Candidato numero {dados.numeroCandidado} já cadastrado.");

            else
            {
                dadosCadastrosList.Add(dados);

                return Ok($"Aluno {dados.nome} cadastrado!");
            }
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(dadosCadastrosList);
        }

        [HttpPost]
        [Route("Votar")]
        public IActionResult Votar(Voto dadosVoto)
        {
            
            var votoExiste = dadosVotoList.Where(a => a.ra == dadosVoto.ra).FirstOrDefault();

            if (votoExiste is not null)
                return BadRequest($"Voto do aluno com RA {dadosVoto.ra} já existe.");

            dadosVotoList.Add(dadosVoto);

            return Ok($"Voto do aluno com o RA {dadosVoto.ra} confirmado.");
        }

        [HttpGet]
        [Route("ConsultarVotosPorCandidato/{numeroCandidato}")]
        public IActionResult ConsultarVotosPorCandidato(int numeroCandidato)
        {
            var votosDoCandidato = dadosVotoList.Where(a => a.numeroCanditado == numeroCandidato).ToList();

            return Ok(votosDoCandidato);
        }
    }
}