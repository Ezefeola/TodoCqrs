using TodoCqrsApp.Domain.Enums;

namespace TodoCqrsApp.Domain.Models
{
    public class Todo : BaseModel<int>
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TodoStatusEnum Status { get; set; } = default!;
    }
}
