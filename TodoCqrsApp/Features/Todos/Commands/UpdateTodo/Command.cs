using MediatR;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Features.Todos.DTOs.Request;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Commands.UpdateTodo
{
    public record UpdateTodoCommand(int todoId, UpdateTodoRequestDto UpdateTodoRequestDto) : IRequest<Result<UpdateTodoResponseDto>>;
}
