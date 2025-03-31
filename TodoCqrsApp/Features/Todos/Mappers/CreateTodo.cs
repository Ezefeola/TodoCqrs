using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Request;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Mappers
{
    public static class CreateTodoMapper
    {
        public static Todo ToModel(this CreateTodoRequestDto createTodoRequestDto)
        {
            return new Todo
            {
                Title = createTodoRequestDto.Title,
                Description = createTodoRequestDto.Description, 
                Status = createTodoRequestDto.Status
            };
        }

        public static CreateTodoResponseDto ToResponse(this Todo todo)
        {
            return new CreateTodoResponseDto
            {
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status
            };
        }

    }
}