using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApp.Common.Data;

[JsonConverter(typeof(JsonStringEnumConverter))]
[Flags]
public enum DaysBitMask : byte
{
    Monday = 1,
    [EnumMember(Value = nameof(Tuesday))]
    Tuesday = 2,
    [EnumMember(Value = nameof(Wednesday))]
    Wednesday = 4,
    [EnumMember(Value = nameof(Thursday))]
    Thursday = 8,
    [EnumMember(Value = nameof(Friday))]
    Friday = 16,
    [EnumMember(Value = nameof(Saturday))]
    Saturday = 32,
    [EnumMember(Value = nameof(Sunday))]
    Sunday = 64,
}