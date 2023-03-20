using bobesponja.Models;

namespace bobesponja.Service
{
    public interface IBobService
    {
        List<Personagem> GetPersonagens();
        List<Especie> GetEspecies();
        Personagem GetPersonagem(string Nome);
        BobEsponjaDto GetBobEsponja();
        DetailsDto GetDetailedPersonagem(string Nome);
        Especie GetEspecie(string Nome);
    }
}