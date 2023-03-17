using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bobesponja.Service
{
    public interface IBobService
    {
        List<Personagem> GetPersonagens();
        List<Especie> GetEspecies();
        PersonagemDto GetPersonagemDto();
        DetailsDto GetDetailedPersonagem (int Numero);
        Especie GetEspecie(string Nome);

    }
}