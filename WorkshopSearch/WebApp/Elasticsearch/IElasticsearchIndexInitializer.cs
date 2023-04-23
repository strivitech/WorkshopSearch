namespace WebApp.Elasticsearch;

public interface IElasticsearchIndexInitializer
{
    Task InitializeAsync();
}
