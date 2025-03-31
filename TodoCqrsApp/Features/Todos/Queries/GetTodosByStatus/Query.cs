using MediatR;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Domain.Enums;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Queries.GetTodosByStatus
{
    public record GetTodosByStatusQuery(TodoStatusEnum todoStatus) : IRequest<Result<List<GetTodosByStatusResponseDto>>>;
}
