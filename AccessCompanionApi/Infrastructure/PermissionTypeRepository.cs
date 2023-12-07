using AccessCompanionApi.Abstractions;
using AccessCompanionApi.Data;
using AccessCompanionApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace AccessCompanionApi.Infrastructure;
public class PermissionTypeRepository : IPermissionTypeRepository
{
    private readonly IDbContext _context;
    public PermissionTypeRepository()
    {
       _context = new MockContext();   
    }
    public PermissionTypeRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Create(PermissionType entity)
    {
        _context.PermissionTypes.ToHashSet<PermissionType>().Add(entity);
        //_context.SaveChanges();
    }
    public IQueryable<PermissionType> ReadAll()
    {
        return _context.PermissionTypes;
    }
    public PermissionType ReadById(int id) => _context.PermissionTypes.ToHashSet<PermissionType>().Single(x => x.Id == id);
    public void Update(PermissionType entity)
    {
        throw new NotImplementedException();
    }
    public void Delete(PermissionType entity)
    {
        throw new NotImplementedException();
    }
}