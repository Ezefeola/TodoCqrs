using MediatR;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Queries.GetTodos
{
    public record GetTodosQuery() : IRequest<Result<List<GetTodosResponseDto>>>;
}