using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commadns.AssignUserRole;
using Restaurants.Application.Users.Commadns.UnassignUserRole;
using Restaurants.Application.Users.Commadns.UpdateUserDetails;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers;


[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommadns commadn) 
    {
        await mediator.Send(commadn);
        return NoContent();
    }


    [HttpPost("userRole")]
    [Authorize(Roles =UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommad commadn)
    {
        await mediator.Send(commadn);
        return NoContent();
    }



    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UnassignUserRole(UnassignUserRoleCommand commadn)
    {
        await mediator.Send(commadn);
        return NoContent();
    }
}
