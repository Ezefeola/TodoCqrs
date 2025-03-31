using TodoCqrsApp.Domain.Enums;

namespace TodoCqrsApp.Features.Todos.DTOs.Response
{
    public class GetTodoByIdResponseDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TodoStatusEnum Status { get; set; } = default!;
    }
}
