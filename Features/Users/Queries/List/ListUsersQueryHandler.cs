using CQRS_Implementation.DataAccess;
using CQRS_Implementation.Features.Users.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Implementation.Features.Users.Queries.List
{
    //context is injected into constructor for data access
    //All handlers should implement the IRequestHandler<T, R> where T is the incoming request (which in our case would be the Query itself), and R would be the response, which is a list of users
    public class GetUsersQueryHandler(DemoAppDbContext context):IRequestHandler<ListUsersQuery, List<UserDto>>
    {
        public async Task<List<UserDto>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            return await context.Users.Select(usr => new UserDto(usr.Id, usr.Name, usr.EmailId, usr.ShortId)).ToListAsync();
        }
    }
}
