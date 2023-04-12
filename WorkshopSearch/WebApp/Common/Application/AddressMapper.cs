using WebApp.Common.Data.ValueObjects;

namespace WebApp.Common.Application;

public static class AddressMapper
{
    public static string ToAddressString(this Address address) =>
        $"{(address.Region != null ? address.Region + ", " : "")}{address.City}, {address.Street}, {address.BuildingNumber}";
}