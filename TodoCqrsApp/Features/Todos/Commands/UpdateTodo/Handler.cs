using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Data;
using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Response;
using TodoCqrsApp.Features.Todos.Mappers;

namespace TodoCqrsApp.Features.Todos.Commands.UpdateTodo
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, Result<UpdateTodoResponseDto>>
    {
        private readonly DbSet<Todo> _dbSet;
        private readonly ApplicationDbContext _dbContext;

        public UpdateTodoHandler(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Todo>();
            _dbContext = dbContext;
        }
        public async Task<Result<UpdateTodoResponseDto>> Handle(UpdateTodoCommand updateTodoCommand, CancellationToken cancellationToken)
        {
            Todo? todoInDb = await _dbSet.FindAsync(updateTodoCommand.todoId, cancellationToken);
            if(todoInDb == null) return Result<UpdateTodoResponseDto>.Failure(HttpStatusCode.NotFound).WithDescription("Couldnt find the desired todo to update.");

            todoInDb.UpdateFromDto(updateTodoCommand.UpdateTodoRequestDto);

            await _dbContext.SaveChangesAsync(cancellationToken);

            UpdateTodoResponseDto updateTodoResponse = UpdateTodoMapper.ToResponse(todoInDb);
            return Result<UpdateTodoResponseDto>.Success(HttpStatusCode.OK);
        }
    }
}