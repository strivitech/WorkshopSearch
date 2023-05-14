using System.Text.Json;
using Nest;
using WebApp.Elasticsearch;

namespace WebApp.Features.Locations;

public class LocationSeeder
{
    private readonly ElasticClient _client;

    public LocationSeeder(IElasticsearchService elasticsearchService)
    {
        _client = elasticsearchService.GetClient();
    }

    public async Task SeedDefaultValuesAsync()
    {
        var existsResponse = await _client.Indices.ExistsAsync(IndexNames.Locations);

        if (!existsResponse.Exists)
        {
            throw new InvalidOperationException("Locations index does not exist.");
        }

        var countResponse = await _client.CountAsync<LocationEsModel>(c => c
            .Index(IndexNames.Locations)
        );

        if (!countResponse.IsValid)
        {
            throw new InvalidOperationException("Failed to count locations.");
        }

        if (countResponse.Count == 0)
        {
            var locations = CreateLocations();
            
            var indexManyResponse = await _client.IndexManyAsync(locations, IndexNames.Locations);
            if (!indexManyResponse.IsValid)
            {
                throw new InvalidOperationException("Failed to index locations.");
            }
        }
    }
    
    private static List<LocationEsModel> CreateLocations()
    {
        return new List<LocationEsModel>
        {
            new() { Id = 1, Name = "Київ,Київ" },
            new() { Id = 2, Name = "Київська,Боярка" },
            new() { Id = 3, Name = "Київська,Кагарлик" },
            new() { Id = 4, Name = "Київська,Бровари" },
            new() { Id = 5, Name = "Київська,Фастів" },
            new() { Id = 6, Name = "Київська,Вишгород" },
            new() { Id = 7, Name = "Київська,Яготин" },
            new() { Id = 8, Name = "Київська,Вишневе" },
            new() { Id = 9, Name = "Київська,Бориспіль" },
            new() { Id = 11, Name = "Львів,Львів" },
            new() { Id = 12, Name = "Львівська,Стрий" },
            new() { Id = 13, Name = "Львівська,Дрогобич" },
            new() { Id = 14, Name = "Львівська,Яворів" },
            new() { Id = 15, Name = "Львівська,Моршин" },
            new() { Id = 16, Name = "Львівська,Сокаль" },
        };
    }
}

