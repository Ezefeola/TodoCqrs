using MediatR;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Features.Todos.DTOs.Request;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Commands.CreateTodo
{
    public record CreateTodoCommand(CreateTodoRequestDto createTodoRequestDto) : IRequest<Result<CreateTodoResponseDto>>;
}
