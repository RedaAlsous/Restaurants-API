
using MediatR;

namespace Restaurants.Application.Users.Commadns.AssignUserRole;

public class AssignUserRoleCommad : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
