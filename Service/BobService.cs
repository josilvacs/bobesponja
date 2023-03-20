using System.Text.Json;
using bobesponja.Models;

namespace bobesponja.Service;

public class BobService : IBobService
{
    private readonly IHttpContextAccessor _session;
    private readonly string personagemFile = @"Data\personagens.json";
    private readonly string especieFile = @"Data\tipos.json";

    public BobService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Personagem> GetPersonagens()
    {
        PopularSessao();
        var personagens = JsonSerializer.Deserialize<List<Personagem>>(_session.HttpContext.Session.GetString("Personagens"));
        return personagens;
    }

    public List<Especie> GetEspecies()
    {
        PopularSessao();
        var especie = JsonSerializer.Deserialize<List<Especie>>(_session.HttpContext.Session.GetString("Especies"));
        return especie;
    }

    public Personagem GetPersonagem(string Nome)
    {
        var personagens = GetPersonagens();
        return personagens.Where(p => p.Nome.Equals(Nome)).FirstOrDefault();
    }

    public BobEsponjaDto GetBobEsponja()
    {
        var bobs = new BobEsponjaDto()
        {
            Personagens = GetPersonagens(),
            Especies = GetEspecies()
        };
        return bobs;
    }

    public DetailsDto GetDetailedPersonagem(string Nome)
    {
        var personagens = GetPersonagens().ToArray();
        var personagem = GetPersonagem(Nome);
        int posicao = Array.IndexOf(personagens, personagem);
        var bob = new DetailsDto()
        {
            Current = personagem,
            Prior = posicao - 1 < 0 ? null : personagens[posicao-1],
            Next = posicao + 1 >=  personagens.Count() ? null : personagens[posicao+1]
        };
        return bob;
    }

    public Especie GetEspecie(string Nome)
    {
        var especies = GetEspecies();
        return especies.Where(e => e.Nome.Equals(Nome)).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Especies")))
        {
            _session.HttpContext.Session.SetString("Personagens", LerArquivo(personagemFile));
            _session.HttpContext.Session.SetString("Especies", LerArquivo(especieFile));
        }
    }

    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}