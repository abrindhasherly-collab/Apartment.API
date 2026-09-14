using ApartmentDomain.Enums;


namespace ApartmentManagement.Application.DTOs.Complaint;

public class UpdateComplaintDto
{
    public int ResidentId { get; set; }

    public int FlatId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ComplaintStatus Status { get; set; }
}