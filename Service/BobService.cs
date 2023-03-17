using System.Text.Json;
using Pokedex.Models;

namespace Pokedex.Services;
    public class PokeService : IBobService
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
            var personagens = JsonSerializer.Deserialize<List<Personagem>>
            (_session.HttpContext.Session.GetString("Personagens"));
            return personagens;
        }
            public List<Tipo> GetTipos()
        {
            PopularSessao();
            var tipos = JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
            return tipos;
        }
            public Pokemon GetPokemon(int Numero)
        {
            var pokemons = GetPokemons();
            return pokemons.Where(p => p.Numero == Numero).FirstOrDefault();
        }
            public PokedexDto GetPokedexDto()
        {
            var pokes = new PokedexDto()
        {
            Pokemons = GetPokemons(),
            Tipos = GetTipos()
        };
            return pokes;
}