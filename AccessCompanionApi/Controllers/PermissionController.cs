using AccessCompanionApi.Abstractions;
using AccessCompanionApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AccessCompanionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private static readonly string[] PermissionTypeDescriptions = new[]
        {
            "Meeting", "Vacation", "Operation", "Last minute event", "Interview", "Warm"
        };

        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(
            ILogger<PermissionController> logger//,
            //IPermissionRepository permissionRepository
        ){
            _logger = logger;
            //_permissionRepository = permissionRepository;
        }

        [HttpGet(Name = "GetPermissions")]
        public IEnumerable<Permission> Get()
        {
            _logger.LogWarning("GET ENDPOINT-------------------");
            int id = 65;
            return Enumerable
                .Range(1, 5)
                .Select(index => new Permission
                {
                    Id = ++id,
                    EmployeeForename = Convert.ToChar(id).ToString() + ". ",
                    EmployeeSurname = "Smith",
                    PermissionDay = DateTime.Now.AddDays(index).Date,
                    PermissionType = new() { Description = PermissionTypeDescriptions[Random.Shared.Next(PermissionTypeDescriptions.Length)] }
                })
                .ToArray();
        }
    }
}
