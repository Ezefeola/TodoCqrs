namespace TodoCqrsApp.Domain.Models
{
    public class BaseModel<T>
    {
        public T Id { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public DateTime? UpdatedAt { get; set; }
    }
}
