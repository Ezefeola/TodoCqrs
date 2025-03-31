using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Data;
using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Response;
using TodoCqrsApp.Features.Todos.Mappers;

namespace TodoCqrsApp.Features.Todos.Queries.GetTodoById
{
    public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, Result<GetTodoByIdResponseDto>>
    {
        private readonly DbSet<Todo> _dbSet;
        private readonly DbContext _dbContext;
        public GetTodoByIdHandler(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Todo>();
            _dbContext = dbContext;

        }

        public async Task<Result<GetTodoByIdResponseDto>> Handle(GetTodoByIdQuery getTodoByIdQuery, CancellationToken cancellationToken)
        {
            Todo? todo = await _dbSet.FindAsync(getTodoByIdQuery.Id, cancellationToken);
            if (todo == null) return Result<GetTodoByIdResponseDto>.Failure(HttpStatusCode.NotFound).WithDescription($"Todo with id: {getTodoByIdQuery.Id} not found");

            GetTodoByIdResponseDto getTodoByIdResponse = GetTodoByIdMapper.ToResponse(todo);
            return Result<GetTodoByIdResponseDto>
                    .Success(HttpStatusCode.OK)
                    .WithPayload(getTodoByIdResponse);
        }
    }
}
