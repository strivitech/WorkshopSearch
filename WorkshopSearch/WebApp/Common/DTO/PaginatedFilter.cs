using System.ComponentModel.DataAnnotations;

namespace WebApp.Common.DTO;

public class PaginatedFilter
{
    public const int DefaultSize = 6;
    public const int MaxSize = 100;
    
    public const int DefaultFrom = MinFrom;
    public const int MinFrom = 1;
    public const int MaxFrom = int.MaxValue;
    
    private int _size = DefaultSize;

    [Range(MinFrom, MaxFrom)]
    public int From { get; set; } = DefaultFrom;
    
    public int Size
    {
        get => _size;

        set
        {
            _size = value switch
            {
                < 0 => DefaultSize,
                > MaxSize => MaxSize,
                _ => value
            };
        }
    }
}