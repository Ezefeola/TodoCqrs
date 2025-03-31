using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Data;
using TodoCqrsApp.Domain.Models;
using TodoCqrsApp.Features.Todos.DTOs.Response;
using TodoCqrsApp.Features.Todos.Mappers;

namespace TodoCqrsApp.Features.Todos.Commands.CreateTodo;
public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Result<CreateTodoResponseDto>>
{
    private readonly DbSet<Todo> _dbSet;
    private readonly ApplicationDbContext _dbContext;

    public CreateTodoHandler(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<Todo>();
        _dbContext = dbContext;
    }

    public async Task<Result<CreateTodoResponseDto>> Handle(CreateTodoCommand createTodoCommand, CancellationToken cancellationToken)
    {
        Todo todo = createTodoCommand.createTodoRequestDto.ToModel();
        await _dbSet.AddAsync(todo, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        CreateTodoResponseDto createTodoResponse = CreateTodoMapper.ToResponse(todo);
        return Result<CreateTodoResponseDto>
                .Success(HttpStatusCode.OK)
                .WithPayload(createTodoResponse)
                .WithDescription("test");
    }
}