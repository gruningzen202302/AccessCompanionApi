using AccessCompanionApi.Domain;
using System.Linq;

namespace AccessCompanionApi.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.PermissionTypes.ToList().Any())
            {
                var permissionTypes = new PermissionType[]
                {
                    new PermissionType
                    {
                        Id = 1,
                        Description = "Permission used by default when no other type is specified",
                    },
                    new PermissionType
                    {
                        Id = 2,
                        Description = "Permission used to access the coworking area",
                    }
                };

                foreach (PermissionType p in permissionTypes)
                {
                    context.PermissionTypes.ToList().Add(p);
                }
                context.SaveChanges();
            }
        }
    }
}