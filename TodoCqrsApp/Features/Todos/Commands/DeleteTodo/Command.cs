using MediatR;
using TodoCqrsApp.Common.Result;

namespace TodoCqrsApp.Features.Todos.Commands.DeleteTodo
{
    public record DeleteTodoCommand(int todoId) : IRequest<Result<string>>;
}
