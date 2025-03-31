using TodoCqrsApp.Domain.Enums;

namespace TodoCqrsApp.Features.Todos.DTOs.Request
{
    public class CreateTodoRequestDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TodoStatusEnum Status { get; set; }
    }
}
