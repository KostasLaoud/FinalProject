using System.ComponentModel.DataAnnotations;

namespace CertStore.Models;

public class UserDetail
{
    [Key]
    public int DetailId { get; set; }

    public string? Id { get; set; }

    //[Required]
    public string Name { get; set; } = string.Empty;


    public string MiddleName { get; set; } = string.Empty;

    //[Required]
    public string LastName { get; set; } = string.Empty;

    //[Required]
    public string Gender { get; set; } = string.Empty;

    public string NativeLanguage { get; set; } = string.Empty;


    public DateTime DateOfBirth { get; set; }


    public string PhotoIdType { get; set; }

    public string PhotoIdNumber { get; set; } = string.Empty;

    public DateTime PhotoIdIssueDate { get; set; }

    public string Address { get; set; } = string.Empty;

    public string AddressLine2 { get; set; } = string.Empty;

    public string CountryOfResidence { get; set; } = string.Empty;

    public string StateProvince { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string LandlinePhone { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

}