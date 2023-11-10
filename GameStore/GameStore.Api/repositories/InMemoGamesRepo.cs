using GameStore.Api.entities;

namespace GameStore.Api.repositories;

public class InMemoGamesRepo : IGamesRepo
{
    //make accessible only to  necessary endpoints
    private readonly List<Game> games = new(){
    new Game()
    {

        Id=1,
        Name="God of War Ragnarök",
        Genre= "Adventure-roleplay",
        Price= 550.00M,
        ReleaseDate= new DateTime(2022,11,9),
        ImageURI="https://placehold.co/100"

    },
    new Game()
    {

        Id=2,
        Name="Fifa 22",
        Genre= "Sports",
        Price= 750.00M,
        ReleaseDate= new DateTime(2022,10,1),
        ImageURI="https://placehold.co/100"

    },
    new Game()
    {

        Id=3,
        Name="Call of Duty: Modern Warfare",
        Genre= " first-person shooter video game",
        Price= 459.60M,
        ReleaseDate= new DateTime(2019,10,25),
        ImageURI="https://placehold.co/100"

    }

      };

    //Get all Games Method.
    public IEnumerable<Game> GetGAll()
    {
        return games;
    }
    //Get a game via its ID method.
    //Method maight return a nullable(NULL),so we put "?" after "Game" objects list to account for this!
    public Game? Get(int id)
    {
        //find a game, store into "game" via its ID if found
        return games.Find(game => game.Id == id);
    }
    // create a new game
    public void Create(Game game)
    {
        //Get max games ID, and just add +1 at the end to make up NEW ID!
        game.Id = games.Max(game => game.Id) + 1;

        //Add newly created game and its NEW ID to GAMES list
        games.Add(game);

    }

    //Update a gamme
    public void Update(Game GameUpdate)
    {
        var inx = games.FindIndex(game => game.Id == GameUpdate.Id);
        games[inx] = GameUpdate;
    }
    //Delete method
    public void Delete(int Id)
    {
        //find a game via its ID
        var index = games.FindIndex(game => game.Id == Id);
        //remove the found ID
        games.RemoveAt(index);
    }
}