using System.ComponentModel.DataAnnotations;

namespace WebApp.Features.Workshops;

public class RegionWithCity{
    [Required]
    [RegularExpression(WorkshopDataConstants.Filter.RegionRegex)]
    public string Region { get; set; } = WorkshopDataConstants.Filter.RegionDefaultValue;
    
    [Required]
    [RegularExpression(WorkshopDataConstants.Filter.CityRegex)]
    public string City { get; set; } = WorkshopDataConstants.Filter.CityDefaultValue;
};