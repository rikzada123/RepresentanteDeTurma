using System.Collections.Generic;
using System.Linq;
using Turma.Models;

namespace Turma.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly List<DadosCadastro> _dadosCadastrosList;
        private readonly List<Voto> _dadosVotoList;

        public CadastroRepository()
        {
            _dadosCadastrosList = new List<DadosCadastro>();
            _dadosVotoList = new List<Voto>();
        }

        public List<DadosCadastro> ListarCandidatos()
        {
            return _dadosCadastrosList;
        }

        public bool CadastrarCandidato(DadosCadastro candidato)
        {
            var candidatoExiste = _dadosCadastrosList.FirstOrDefault(a => a.numeroCandidado == candidato.numeroCandidado);
            if (candidatoExiste != null) 
                return false;

            _dadosCadastrosList.Add(candidato);
            return true;
        }

        public bool Votar(Voto voto)
        {
            var votoExiste = _dadosVotoList.FirstOrDefault(a => a.ra == voto.ra);
            if (votoExiste != null) 
                return false;

            _dadosVotoList.Add(voto);
            return true;
        }

        public List<Voto> ConsultarVotosPorCandidato(int numeroCandidato)
        {
            return _dadosVotoList.Where(a => a.numeroCanditado == numeroCandidato).ToList();
        }
    }
}
