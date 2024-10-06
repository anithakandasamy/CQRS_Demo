using CQRS_Implementation.DataAccess;
using CQRS_Implementation.Features.Users.Dtos;
using MediatR;

namespace CQRS_Implementation.Features.Users.Queries.Get
{
    //context is injected into constructor for data access
    //All handlers should implement the IRequestHandler<T, R> where T is the incoming request (which in our case would be the Query itself), and R would be the response, which is a list of users
    public class GetUsersQueryHandler(DemoAppDbContext context):IRequestHandler<GetUsersQuery, UserDto?>
    {
        public async Task<UserDto?> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(request.Id);
            if (user == null) return null;
            return new UserDto(user.Id, user.Name, user.EmailId, user.ShortId);
        }
    }
}
