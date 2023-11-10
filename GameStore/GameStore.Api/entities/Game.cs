using System.ComponentModel.DataAnnotations;

//Define entities Namespace
namespace GameStore.Api.entities;

public class Game
{
    public int Id { get; set; }

    //add anotations for Server-side validation
    [Required]
    //string length <50char
    [StringLength(50)]
    public required string Name { get; set; }// using the "required" to make it REQUIRED

    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }

    //Validate that Price is NOT above 2000
    [Range(1,2000)]
    public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; }

    [Url]
    [StringLength(90)]
    public required string ImageURI { get; set; }
}