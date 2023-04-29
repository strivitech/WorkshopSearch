using Nest;
using WebApp.Elasticsearch;

namespace WebApp.Features.Workshops;

public class WorkshopIndexInitializer : IWorkshopIndexInitializer
{
    private readonly WorkshopEsSeeder _workshopEsSeeder;
    private readonly ElasticClient _client;

    public WorkshopIndexInitializer(WorkshopEsSeeder workshopEsSeeder, IElasticsearchService elasticsearchService)
    {
        _workshopEsSeeder = workshopEsSeeder;
        _client = elasticsearchService.GetClient();
    }

    public async Task InitializeAsync()
    {
        var existsResponse = await _client.Indices.ExistsAsync(IndexNames.Workshops);

        if (!existsResponse.Exists)
        {
            var createIndexResponse = await _client.Indices.CreateAsync(IndexNames.Workshops, c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(an => an
                            .Icu(AnalyzerNames.Icu, i => 
                                i.Method(IcuNormalizationType.CompatibilityCaseFold)
                            )
                        )
                    )
                )
                .Map<WorkshopEsModel>(m => m
                    .Properties(p => p
                        .Text(t => t
                            .Name(n => n.Title)
                            .Analyzer(AnalyzerNames.Icu)
                        )
                        .Text(t => t
                            .Name(n => n.Description)
                            .Analyzer(AnalyzerNames.Icu)
                        )
                        .Keyword(k => k
                            .Name(n => n.Id)
                        )
                    )
                )
            );

            if (!createIndexResponse.Acknowledged)
            {
                throw new Exception("Failed to create Elasticsearch index.");
            }
        }
        
        await _workshopEsSeeder.SeedDefaultValuesAsync();
    }
}