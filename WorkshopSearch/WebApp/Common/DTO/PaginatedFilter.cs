using System.ComponentModel.DataAnnotations;

namespace WebApp.Common.DTO;

public class PaginatedFilter
{
    public const int DefaultSize = 6;
    public const int MaxSize = 100;
    
    private int _size = DefaultSize;

    [Range(0, int.MaxValue)]
    public int From { get; set; } = 0;
    
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