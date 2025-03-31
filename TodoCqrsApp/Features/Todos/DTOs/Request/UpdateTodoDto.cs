using TodoCqrsApp.Domain.Enums;

namespace TodoCqrsApp.Features.Todos.DTOs.Request
{
    public class UpdateTodoRequestDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TodoStatusEnum? Status { get; set; }
    }
}
