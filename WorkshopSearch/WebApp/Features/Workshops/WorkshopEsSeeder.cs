using Nest;
using WebApp.Database.Main;
using WebApp.Elasticsearch;

namespace WebApp.Features.Workshops;

public class WorkshopEsSeeder
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly ElasticClient _client;

    public WorkshopEsSeeder(ApplicationDbContext applicationDbContext, IElasticsearchService elasticsearchService)
    {
        _applicationDbContext = applicationDbContext;
        _client = elasticsearchService.GetClient();
    }

    public async Task SeedDefaultValuesAsync()
    {
        var existsResponse = await _client.Indices.ExistsAsync(IndexNames.Workshops);

        if (!existsResponse.Exists)
        {
            throw new InvalidOperationException("Workshops index does not exist.");
        }
        
        var countResponse = await _client.CountAsync<WorkshopEsModel>(c => c
            .Index(IndexNames.Workshops)
        );

        if (!countResponse.IsValid)
        {
            throw new InvalidOperationException("Failed to count Workshops.");
        }

        if (countResponse.Count == 0)
        {
            var locations = CreateWorkshops();
            
            var indexManyResponse = await _client.IndexManyAsync(locations, IndexNames.Workshops);
            if (!indexManyResponse.IsValid)
            {
                throw new InvalidOperationException("Failed to index Workshops.");
            }
        }
    }
    
    private List<WorkshopEsModel> CreateWorkshops()
    {
        ThrowIfNoWorkshops();

        var workshopEsModels = WorkshopsSeeder
            .Workshops(_applicationDbContext)
            .Select(workshop => new WorkshopEsModel
            {
                Id = workshop.Id.Value,
                Region = workshop.Address.Region,
                City = workshop.Address.City,
                Title = workshop.Title,
                Description = workshop.Description,
            }).ToList();
        
        return workshopEsModels;
        
        void ThrowIfNoWorkshops()
        {
            if (!_applicationDbContext.Workshops.Any())
            {
                throw new InvalidOperationException("Workshops table is empty.");
            }
        }
    }
}