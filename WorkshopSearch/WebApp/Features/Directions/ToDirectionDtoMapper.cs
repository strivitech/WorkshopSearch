namespace WebApp.Features.Directions;

public static class ToDirectionDtoMapper
{
    public static DirectionDto ToDirectionDto(this Direction direction)
    {
        return new DirectionDto
        {
            Id = direction.Id.Value,
            Name = direction.Name
        };
    }
}