using System.Collections.Generic;
using Turma.Models;

namespace Turma.Repositories
{
    public interface ICadastroRepository
    {
        List<DadosCadastro> ListarCandidatos();
        bool CadastrarCandidato(DadosCadastro candidato);
        bool Votar(Voto voto);
        List<Voto> ConsultarVotosPorCandidato(int numeroCandidato);
    }
}
