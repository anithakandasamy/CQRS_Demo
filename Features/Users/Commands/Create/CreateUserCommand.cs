using MediatR;

namespace CQRS_Implementation.Features.Users.Commands.Create
{
    //Each query should inherit from IRequest<T> where T is the type of object to be returned
    public record CreateUserCommand(int Id, string Name, string EmailId, string ShortId): IRequest<int>;
}
