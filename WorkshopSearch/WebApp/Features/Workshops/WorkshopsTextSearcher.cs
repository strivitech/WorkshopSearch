﻿using Elasticsearch.Net;
using Nest;
using WebApp.Elasticsearch;

namespace WebApp.Features.Workshops;

public class WorkshopsTextSearcher : IWorkshopsTextSearcher
{
    private readonly ElasticClient _elasticClient;
    private const int MaxSizeResponse = 10000;

    public WorkshopsTextSearcher(IElasticsearchService elasticsearchService)
    {
        _elasticClient = elasticsearchService.GetClient();
    }

    public async Task<List<Guid>> FindIdsAsync(TextSearcherFilter filter)
    {
        var searchResponse = await _elasticClient.SearchAsync<WorkshopEsModel>(s => s
            .Index(IndexNames.Workshops)
            .Query(q => q
                .Bool(b => b
                    .Must(
                        mu => mu.Match(m => m
                            .Field(f => f.Region)
                            .Query(filter.Region)),
                        mu => mu.Match(m => m
                            .Field(f => f.City)
                            .Query(filter.City)),
                        mu => mu.Terms(t => t
                            .Field(f => f.CategoryIds)
                            .Terms(filter.CategoryId)),
                        mu => mu.MultiMatch(mm => mm
                            .Fields(fd => fd
                                .Field(wem => wem.Title)
                                .Field(wem => wem.Description)
                            )
                            .Query(filter.Text)
                            .Fuzziness(Fuzziness.Auto)
                        )
                    )
                )
            )
            .Size(MaxSizeResponse)
            .Source(sf => sf.Includes(i => i.Field(f => f.Id)))
        );
        
        if (!searchResponse.IsValid)
        {
            throw new InvalidOperationException("Failed to search workshops.");
        }

        return searchResponse.Documents.Select(w => w.Id).ToList();
    }
}