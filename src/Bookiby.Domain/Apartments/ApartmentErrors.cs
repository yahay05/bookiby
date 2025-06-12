using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Apartments;

public static class ApartmentErrors
{
    public static Error NotFound = new Error(
        "Apartment.NotFound", 
        "The apartment with the specified identifier was not found.");
}