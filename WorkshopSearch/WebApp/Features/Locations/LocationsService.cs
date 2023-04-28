using WebApp.Elasticsearch;

namespace WebApp.Features.Locations;

public class LocationsService : ILocationsService
{
    private const int GetBySearchTermMaxSize = 25;
    private readonly IElasticsearchService _elasticsearchService;

    public LocationsService(IElasticsearchService elasticsearchService)
    {
        _elasticsearchService = elasticsearchService;
    }

    public async Task<List<LocationResponse>> GetBySearchTermAsync(string searchTerm)
    {
        var client = _elasticsearchService.GetClient();
        var searchResponse = await client.SearchAsync<LocationEsModel>(s => s
            .Index(IndexNames.Locations)
            .Size(GetBySearchTermMaxSize)
            .Query(q => q
                .MatchPhrasePrefix(m => m
                    .Field(f => f.Name)
                    .Query(searchTerm)
                )
            )
        );

        if (!searchResponse.IsValid)
        {
            throw new InvalidOperationException("Failed to search locations.");
        }

        return searchResponse.Documents.Select(locationEs => new LocationResponse
            { Name = locationEs.Name }).ToList();
    }
}