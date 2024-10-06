using CQRS_Implementation.Features.Users.Dtos;
using MediatR;

namespace CQRS_Implementation.Features.Users.Queries.Get
{
    //Each query should inherit from IRequest<T> where T is the type of object to be returned
    public record GetUsersQuery(int Id): IRequest<UserDto?>;
}
