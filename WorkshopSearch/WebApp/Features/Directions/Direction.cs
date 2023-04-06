using WebApp.Common.Data.Entities;

namespace WebApp.Features.Directions;

public record DirectionId(int Value);

public class Direction : BaseEntity<DirectionId>
{
    public string Name { get; set; } = null!;
}
