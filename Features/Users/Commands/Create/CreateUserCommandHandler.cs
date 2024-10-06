using CQRS_Implementation.DataAccess;
using CQRS_Implementation.Domain;
using MediatR;

namespace CQRS_Implementation.Features.Users.Commands.Create
{
    //context is injected into constructor for data access
    //All handlers should implement the IRequestHandler<T, R> where T is the incoming request (which in our case would be the Query itself), and R would be the response, which is a list of users
    public class UpdateUserCommandHandler(DemoAppDbContext context):IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.Id, command.Name, command.EmailId, command.ShortId);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}
