using WebApp.Common.Data.ValueObjects;

namespace WebApp.Features.Workshops;

public static class ToAddressDtoMapper
{
    public static AddressDto ToAddressDto(this Address address) =>
        new(address.Region, address.City, address.Street, address.BuildingNumber);
}