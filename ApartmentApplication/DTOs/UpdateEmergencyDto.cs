using ApartmentDomain.Enums;


namespace ApartmentManagement.Application.DTOs.Emergency;

public class UpdateEmergencyDto
{
    public int ResidentId { get; set; }

    public int FlatId { get; set; }

    public string EmergencyType { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public EmergencyPriority Priority { get; set; }

    public EmergencyStatus Status { get; set; }
}