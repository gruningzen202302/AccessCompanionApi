using AccessCompanionApi.Abstractions;
using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;

namespace AccessCompanionApi.Infrastructure;

public class PermissionRepository : IPermissionRepository
{
    private readonly IDbContext _context;
    public PermissionRepository() { _context = new MockContext();}
    public PermissionRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Create(Permission entity)
    {
        _context.Permissions.ToHashSet<Permission>().Add(entity);
    }
    public IQueryable<Permission> ReadAll()
    {
        return _context.Permissions;
    }
    public Permission ReadById(int id) => _context
        .Permissions
        .ToHashSet<Permission>()
        .Single(x => x.Id == id);
    public void Update(Permission entity)
    {
        throw new NotImplementedException();
    }
    public void Delete(Permission entity)
    {
        throw new NotImplementedException();
    }
    IQueryable<Permission> IRepository<Permission>.ReadAll() => _context.Permissions.AsQueryable();

    Permission IRepository<Permission>.ReadById(int id)=> _context
        .Permissions
        .Single(x => x.Id.Equals(id));

    public IQueryable<Permission> Read(Func<Permission, bool> predicate) => _context.Permissions.Where(predicate).AsQueryable();

    Permission ReadOne(Func<Permission, bool> predicate) => _context
        .Permissions
        .Single(predicate);
}