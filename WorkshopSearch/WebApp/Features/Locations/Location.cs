using Nest;

namespace WebApp.Features.Locations;

public class Location
{
    [Keyword]
    public string Id { get; set; } = null!;

    [Text(Analyzer = "ukrainian_analyzer")]
    public string LocationName { get; set; } = null!;
}

