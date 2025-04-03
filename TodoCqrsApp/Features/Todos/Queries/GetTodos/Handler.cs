using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Data;
using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Response;

namespace TodoCqrsApp.Features.Todos.Queries.GetTodos
{
    public class GetTodosHandler : IRequestHandler<GetTodosQuery, Result<List<GetTodosResponseDto>>>
    {
        private readonly DbSet<Todo> _dbSet;
        private readonly DbContext _dbContext;
        public GetTodosHandler(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Todo>();
            _dbContext = dbContext;
        }
        public async Task<Result<List<GetTodosResponseDto>>> Handle(GetTodosQuery getTodosQuery, CancellationToken cancellationToken)
        {
            List<Todo> todos = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

            List<GetTodosResponseDto> getTodosResponse = todos.Select(todo => new GetTodosResponseDto
            {
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status
            }).ToList();

            return Result<List<GetTodosResponseDto>>
                    .Success(HttpStatusCode.OK)
                    .WithPayload(getTodosResponse);
        }
    }
}