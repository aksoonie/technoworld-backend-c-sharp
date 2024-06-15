using technoworld.Shared.Domain.Repositories;
using technoworld.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace technoworld.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _context;
    public UnitOfWork(AppDBContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}