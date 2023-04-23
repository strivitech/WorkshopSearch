using Nest;
using WebApp.Elasticsearch;

namespace WebApp.Features.Locations
{
    public class LocationIndexInitializer : ILocationIndexInitializer
    {
        private readonly ElasticClient _client;

        public LocationIndexInitializer(IElasticsearchService elasticsearchService)
        {
            _client = elasticsearchService.GetClient();
        }

        public async Task InitializeAsync()
        {
            const string indexName = "locations";
            var existsResponse = await _client.Indices.ExistsAsync(indexName);

            if (!existsResponse.Exists)
            {
                var createIndexResponse = await _client.Indices.CreateAsync(indexName, c => c
                    .Settings(s => s
                        .Analysis(a => a
                            .Analyzers(an => an
                                .Standard("ukrainian_analyzer", sa => sa
                                    .StopWords("_ukrainian_")
                                )
                            )
                        )
                    )
                    .Map<Location>(m => m
                        .Properties(p => p
                            .Text(t => t
                                .Name(n => n.LocationName)
                                .Analyzer("ukrainian_analyzer")
                            )
                        )
                    )
                );

                if (!createIndexResponse.Acknowledged)
                {
                    throw new Exception("Failed to create Elasticsearch index.");
                }
            }
        }
    }
}