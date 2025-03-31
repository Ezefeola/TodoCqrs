using MediatR;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Queries.GetTodoById
{
    public record GetTodoByIdQuery(int Id) : IRequest<Result<GetTodoByIdResponseDto>>;
}
