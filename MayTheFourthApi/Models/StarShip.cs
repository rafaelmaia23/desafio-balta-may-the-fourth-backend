using System.ComponentModel.DataAnnotations;

namespace MayTheFourthApi.Models;

public class StarShip
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string CostInCredits { get; set; } = string.Empty;
    public string Length {  get; set; } = string.Empty;
    public string MaxSpeed {  get; set; } = string.Empty;
    public string Crew { get; set; } = string.Empty;
    public string Passengers {  get; set; } = string.Empty;
    public string CargoCapacity { get; set; } = string.Empty;
    public string HyperDriveRating {  get; set; } = string.Empty;
    public string Mglt { get; set; } = string.Empty;
    public string Consumables { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public List<Movie> Movies { get; set; }

}
