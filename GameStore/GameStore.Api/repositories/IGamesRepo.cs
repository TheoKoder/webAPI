using GameStore.Api.entities;

namespace GameStore.Api.repositories;

//Generate Inferface to account for Dependecy Injections
public interface IGamesRepo
{

    void Create(Game game);
    void Delete(int id);

    Game? Get(int Id);

    IEnumerable<Game> GetGAll();

    void Update(Game gameUpdate);
}
