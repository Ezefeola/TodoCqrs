using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Data;
using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Queries.GetTodosByStatus
{
    public class GetTodosByStatusHandler : IRequestHandler<GetTodosByStatusQuery, Result<List<GetTodosByStatusResponseDto>>>
    {
        private readonly DbSet<Todo> _dbSet;
        private readonly DbContext _dbContext;
        public GetTodosByStatusHandler(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Todo>();
            _dbContext = dbContext; 
        }

        public async Task<Result<List<GetTodosByStatusResponseDto>>> Handle(GetTodosByStatusQuery getTodosByStatusQuery, CancellationToken cancellationToken)
        {
            List<Todo> todos = await _dbSet.AsNoTracking().Where(t => t.Status == getTodosByStatusQuery.todoStatus).ToListAsync(cancellationToken);
            if (todos is null) return Result<List<GetTodosByStatusResponseDto>>.Failure(HttpStatusCode.NotFound).WithDescription("There are no Todos to show.");

            List<GetTodosByStatusResponseDto> getTodosByStatusResponse = todos.Select(todo => new GetTodosByStatusResponseDto
            {
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status
            }).ToList();

            return Result<List<GetTodosByStatusResponseDto>>.Success(HttpStatusCode.OK).WithPayload(getTodosByStatusResponse);
        }
    }
}