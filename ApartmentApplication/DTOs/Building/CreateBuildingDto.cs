namespace ApartmentApplication.DTOs.Building;

public class CreateBuildingDto
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public int TotalFloors { get; set; }

    public int TotalFlats { get; set; }
}