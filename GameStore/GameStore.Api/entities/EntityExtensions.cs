using GameStore.Api.Dtos;

namespace GameStore.Api.entities;

//All Extesnsions Are Static so Make this extension static as well
public static class EntityExtensions
{
    //Extend Game Entity as parameter injection
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageURI
        );
    }
}