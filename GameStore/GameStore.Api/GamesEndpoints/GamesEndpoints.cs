using GameStore.Api.Dtos;
using GameStore.Api.entities;
using GameStore.Api.repositories;
using System.Linq;

namespace GameStore.Api.Endpoints;

//declare enpoints calss,
//Move Objects from Program.cs into GameEndpoints.cs for better code readability
public static class GamesEndpoints
{
    const string GetGameEndPoint ="GetGame";

//decalare a few games in list DATA STRUCTURE
//make GAME list static since it is being used inside a static class AFTER bringing in from PROGRAM.CS

    //Define extension method
    //IEndpointRouteBuilder is the extention type, "this" keyword allows us to extend
    public static RouteGroupBuilder MapGamesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        //using a MapGroup "group" instead of  just "app", to shorten code and GROUP multiple endpoints together
        var group = endpoints.MapGroup("/games")
                      .WithParameterValidation();//include the Sql parameter validation logic from "Games.cs"
                                                 
        // GET ALL games 
        group.MapGet("/", (IGamesRepo inMemoGames) => 
        inMemoGames.GetGAll().Select(game=>game.AsDto()));


        //get games by ID,using FIND() method
        group.MapGet("/{id}", (IGamesRepo inMemoGames,int id) =>
        {
            Game? game = inMemoGames.Get(id);

            //Account for null, ERROR HANDLING
            if (game == null)
            {
                return Results.NotFound($"Game with ID {id} was not found.");
            }
            else
            {
                return Results.Ok(game.AsDto());
            }
        }).WithName(GetGameEndPoint);//Endpoint


        //Create a game resource Api
        group.MapPost("/", (IGamesRepo inMemoGames,CreateGameDto gameDto) =>
        {
            //Create New Game object for DTOs
            Game game= new()
            {
                Name=gameDto.Name,
                Genre= gameDto.Genre,
                Price=gameDto.Price,
                ReleaseDate=gameDto.ReleaseDate,
                ImageURI=gameDto.ImageURI

            };

            //Send new game DTO into inMemo repository 
             inMemoGames.Create(game);

            //RETURN ENDPOINT, NEW ID, NEW game
            return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game);
        });
        //Updating a Games list object
        group.MapPut("/{id}", (IGamesRepo inMemoGames,int id, UpdateGameDto UpdatedGameDto) =>
        {

            //find the game
            Game? ExistingGame = inMemoGames.Get(id);

            //account for if the game is found or not found

            //if game ID not found 
            if (ExistingGame is null)
            {
                return Results.NotFound();
            }

            //Store update from "existingGame" query into "updatedGame"
            ExistingGame.Name = UpdatedGameDto.Name;
            ExistingGame.Genre = UpdatedGameDto.Genre;
            ExistingGame.Price = UpdatedGameDto.Price;
            ExistingGame.ReleaseDate = UpdatedGameDto.ReleaseDate;
            ExistingGame.ImageURI = UpdatedGameDto.ImageURI;

            inMemoGames.Update(ExistingGame);

            return Results.NoContent();
        });

        //Delete a game object BY ID
        group.MapDelete("/{id}", (IGamesRepo inMemoGames,int id) =>
        {
            Game? ExistingGame = inMemoGames.Get(id);

            //account for if the game is found or not found

            //if game ID is found, delete 
            if (ExistingGame != null)
            {
                inMemoGames.Delete(id);
            }
            //No change if game not found, delete Empty and return Successful status

            return Results.NoContent();
        });

        return group;// return GROUP incase to account for Continous calls of GAMESENDPOINT.CS

    }
}