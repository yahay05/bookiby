using Bookiby.Domain.Apartments;

namespace Bookiby.Infrastructure.Repositories;

public sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}