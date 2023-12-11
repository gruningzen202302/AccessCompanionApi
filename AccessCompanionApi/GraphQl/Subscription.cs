using AccessCompanionApi.Domain;
using HotChocolate;

namespace AccessCompanionApi.GraphQl;

public class Subscription
{
    [Subscribe, Topic]
    public Permission OnPermissionCreated([EventMessage] Permission permission) => permission;
}