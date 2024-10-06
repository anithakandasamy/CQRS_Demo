using CQRS_Implementation.DataAccess;
using MediatR;

namespace CQRS_Implementation.Features.Users.Commands.Update
{
    //context is injected into constructor for data access
    //All handlers should implement the IRequestHandler<T, R> where T is the incoming request (which in our case would be the Query itself), and R would be the response, which is a list of users
    public class UpdateUserCommandHandler(DemoAppDbContext context):IRequestHandler<UpdateUserCommand, int?>
    {
        public async Task<int?> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(command.Id);
            if (user == null) return null;
            user.Name = command.Name;
            user.EmailId = command.EmailId;
            user.ShortId = command.ShortId;
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return command.Id;
        }
    }
}
