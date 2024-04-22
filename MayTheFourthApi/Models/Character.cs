using System.ComponentModel.DataAnnotations;

namespace MayTheFourthApi.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
    public string Weigth { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public string SkinColor { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public List<Planet> Planets {  get; set; } 
    public List<Movie> Movies { get; set; }


}
