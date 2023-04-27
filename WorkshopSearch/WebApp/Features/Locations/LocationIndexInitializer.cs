using Nest;
using WebApp.Elasticsearch;

namespace WebApp.Features.Locations
{
    public class LocationIndexInitializer : ILocationIndexInitializer
    {
        private readonly LocationSeeder _locationSeeder;
        private readonly ElasticClient _client;

        public LocationIndexInitializer(IElasticsearchService elasticsearchService, LocationSeeder locationSeeder)
        {
            _locationSeeder = locationSeeder;
            _client = elasticsearchService.GetClient();
        }

        public async Task InitializeAsync()
        {
            var existsResponse = await _client.Indices.ExistsAsync(IndexNames.Locations);

            if (!existsResponse.Exists)
            {
                var createIndexResponse = await _client.Indices.CreateAsync(IndexNames.Locations, c => c
                    .Settings(s => s
                        .Analysis(a => a
                            .Analyzers(an => an
                                .Standard("ukrainian_analyzer", sa => sa
                                    .StopWords("_ukrainian_")
                                )
                            )
                        )
                    )
                    .Map<LocationEsModel>(m => m
                        .Properties(p => p
                            .Text(t => t
                                .Name(n => n.Name)
                                .Analyzer("ukrainian_analyzer")
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
            
            await _locationSeeder.SeedDefaultValuesAsync();
        }
    }
}