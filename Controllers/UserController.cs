using CQRS_Implementation.Features.Users.Commands.Create;
using CQRS_Implementation.Features.Users.Commands.Update;
using CQRS_Implementation.Features.Users.Queries.Get;
using CQRS_Implementation.Features.Users.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;
        public UserController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IResult> GetUserListAsync()
        {
            var users = await _mediator.Send(new ListUsersQuery());

            return Results.Ok(users);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IResult> GetUserByIdAsync(int id)
        {
            var user = await _mediator.Send(new GetUsersQuery(id));
            if (user == null)
                return Results.BadRequest($"User# {id} not found!");
            return Results.Ok(user);
        }

        [HttpPost]
        public async Task<IResult> AddUserAsync(CreateUserCommand user)
        {
            var id = await _mediator.Send(user);
            return Results.Ok(id);
        }

        [HttpPut]
        public async Task<IResult> UpdateUserAsync(UpdateUserCommand user)
        {
            var id = await _mediator.Send(user);
            if (id == null)
                return Results.BadRequest($"User# {id} not found!");
            return Results.Ok(id);
        }
    }
}
