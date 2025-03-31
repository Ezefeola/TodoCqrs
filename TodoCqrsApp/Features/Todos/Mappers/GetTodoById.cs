using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Mappers
{
    public static class GetTodoByIdMapper
    {
        public static GetTodoByIdResponseDto ToResponse(this Todo todo)
        {
            return new GetTodoByIdResponseDto
            {
                Title = todo.Title, 
                Description = todo.Description,
                Status = todo.Status
            };
        }
    }
}
