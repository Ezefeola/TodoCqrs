using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Data;
using TodoCqrsApp.Domain.Models;

namespace TodoCqrsApp.Features.Todos.Commands.DeleteTodo
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, Result<string>>
    {
        private protected DbSet<Todo> _dbSet;
        private protected DbContext _dbContext;
        public DeleteTodoHandler(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Todo>();
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteTodoCommand deleteTodoCommand, CancellationToken cancellationToken)
        {
            Todo? todoToDelete = await _dbSet.FindAsync(deleteTodoCommand.todoId, cancellationToken);
            if (todoToDelete == null) return Result<string>.Failure(HttpStatusCode.NotFound)
                                                           .WithDescription("Todo to delete not found");

            _dbSet.Remove(todoToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(HttpStatusCode.NoContent)
                                 .WithDescription("Todo deleted correctly");
        }
    }
}
