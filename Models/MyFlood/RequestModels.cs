using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models.MyFlood;

public class LocationDetail
{
    [Display(Name = "Address Line 1")]
    [Required]
    public string? AddressLine1 { get; set; }

    [Display(Name = "Address Line 2")]
    public string? AddressLine2 { get; set; }

    [Display(Name = "Address Line 3")]
    public string? AddressLine3 { get; set; }

    public string? County { get; set; }

    [Display(Name = "State Code")]
    [Required]
    [StringLength(2, MinimumLength = 2)]
    public string? StateCode { get; set; }

    [Display(Name = "ZIP Code")]
    [Required]
    [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Please enter a valid ZIP code")]
    public string? Zip { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}

public class Foundation
{
    [Display(Name = "Foundation Type")]
    [Required]
    public FoundationType FoundationType { get; set; }

    [Display(Name = "Additional Foundation Type")]
    public AdditionalFoundationType? AdditionalFoundationType { get; set; }
}

public class Residential
{
    [Display(Name = "Occupancy Type")]
    [Required]
    public ResidentialOccupancyType OccupancyType { get; set; }

    [Display(Name = "Construction Type")]
    [Required]
    public ResidentialConstructionType ConstructionType { get; set; }

    [Display(Name = "Attached Garage Type")]
    [Required]
    public AttachedGarageType AttachedGarageType { get; set; }
}