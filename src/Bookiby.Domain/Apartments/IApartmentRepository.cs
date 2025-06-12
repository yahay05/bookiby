namespace Bookiby.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}