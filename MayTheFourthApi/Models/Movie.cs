using System.ComponentModel.DataAnnotations;

namespace MayTheFourthApi.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string episode { get; set; }
    public string OpeningCrawl { get; set; }
    public string Director { get; set; }
    public string Producer { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<Character> Characters { get; set; }
    public List<Planet> Planets { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public List<Starship> Starships { get; set; }
}
