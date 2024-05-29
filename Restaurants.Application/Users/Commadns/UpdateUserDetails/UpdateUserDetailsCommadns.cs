

using MediatR;

namespace Restaurants.Application.Users.Commadns.UpdateUserDetails;

public class UpdateUserDetailsCommadns : IRequest
{
    public DateOnly DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}
