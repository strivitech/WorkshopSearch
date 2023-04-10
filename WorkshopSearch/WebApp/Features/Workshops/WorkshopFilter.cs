using System.ComponentModel.DataAnnotations;
using WebApp.Common.Data;
using WebApp.Common.DTO;

using Filter = WebApp.Features.Workshops.WorkshopDataConstants.Filter;

namespace WebApp.Features.Workshops;

public class WorkshopFilter : PaginatedFilter
{
    [MaxLength(Filter.MaxTextLength)]
    public string? Text { get; set; }
    
    [Required]
    [Range(Filter.MinCategoryId, Filter.MaxCategoryId)]
    public int? CategoryId { get; set; }
    
    [Range(Filter.MinAgeMinValue, Filter.MinAgeMaxValue)]
    public int MinAge { get; set; } = Filter.MinAgeDefaultValue;
    
    [Range(Filter.MaxAgeMinValue, Filter.MaxAgeMaxValue)]
    public int MaxAge { get; set; } = Filter.MaxAgeDefaultValue;
    
    [Range(Filter.MinPriceMinValue, Filter.MinPriceMaxValue)]
    public int MinPrice { get; set; } = Filter.MinPriceDefaultValue;
    
    [Range(Filter.MaxPriceMinValue, Filter.MaxPriceMaxValue)]
    public int MaxPrice { get; set; } = Filter.MaxPriceDefaultValue;
    
    [MaxLength(Filter.MaxLengthWorkingDaysArray)]
    public List<DaysBitMask>? WorkingDays { get; set; }
}