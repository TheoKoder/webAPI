using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

//Declare Records inside a Dto
public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageURI
);

//Create Game dto record

public record CreateGameDto(

    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 2000)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImageURI
    
);

public record UpdateGameDto(

    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 2000)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImageURI

);