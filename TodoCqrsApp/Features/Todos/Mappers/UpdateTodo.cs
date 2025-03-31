using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Request;
using TodoCqrsApp.Features.Todos.DTOs.Response;


namespace TodoCqrsApp.Features.Todos.Mappers
{
    public static class UpdateTodoMapper
    {
        public static void UpdateFromDto(this Todo existingTodo, UpdateTodoRequestDto updateTodoRequestDto)
        {
            existingTodo.Title = updateTodoRequestDto.Title ?? existingTodo.Title;
            existingTodo.Description = updateTodoRequestDto.Description ?? existingTodo.Description;
            existingTodo.Status = updateTodoRequestDto.Status ?? existingTodo.Status;
        }

        public static UpdateTodoResponseDto ToResponse(this Todo todo)
        {
            return new UpdateTodoResponseDto
            {
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status
            };
        }
    } 
}