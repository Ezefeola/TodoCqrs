using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoCqrsApp.Common.Result;
using TodoCqrsApp.Domain.Enums;
using TodoCqrsApp.Features.Todos.Commands.CreateTodo;
using TodoCqrsApp.Features.Todos.Commands.DeleteTodo;
using TodoCqrsApp.Features.Todos.Commands.UpdateTodo;
using TodoCqrsApp.Features.Todos.DTOs.Request;
using TodoCqrsApp.Features.Todos.DTOs.Response;
using TodoCqrsApp.Features.Todos.Queries.GetTodoById;
using TodoCqrsApp.Features.Todos.Queries.GetTodos;
using TodoCqrsApp.Features.Todos.Queries.GetTodosByStatus;

namespace TodoCqrsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly ISender _sender;

        public TodoController(ISender sender)
        {   
            _sender = sender;
        }

        [HttpGet]
        public async Task<Result<List<GetTodosResponseDto>>> GetTodos()
        {
            Result<List<GetTodosResponseDto>> result = await _sender.Send(new GetTodosQuery());
            return result;
        }

        [HttpGet("id/{id:int}")]
        public async Task<Result<GetTodoByIdResponseDto>> GetTodoById([FromRoute] int id)
        {
            Result<GetTodoByIdResponseDto> result = await _sender.Send(new GetTodoByIdQuery(id));
            return result;
        }
        [HttpGet("status")]
        public async Task<Result<List<GetTodosByStatusResponseDto>>> GetTodoByStatus([FromQuery] TodoStatusEnum todoStatus)
        {
            Result<List<GetTodosByStatusResponseDto>> result = await _sender.Send(new GetTodosByStatusQuery(todoStatus));
            return result;
        }

        [HttpPost]
        public async Task<Result<CreateTodoResponseDto>> CreateTodo(CreateTodoRequestDto createTodoRequestDto)
        {
            Result<CreateTodoResponseDto> result = await _sender.Send(new CreateTodoCommand(createTodoRequestDto));
            return result;
        }

        [HttpPatch("{id:int}")]
        public async Task<Result<UpdateTodoResponseDto>> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequestDto updateTodoRequestDto)
        {
            Result<UpdateTodoResponseDto> result = await _sender.Send(new UpdateTodoCommand(id, updateTodoRequestDto));
            return result;
        }

        [HttpDelete]
        public async Task<Result<string>> DeleteTodo(int todoId)
        {
            Result<string> result = await _sender.Send(new DeleteTodoCommand(todoId));
            return result;
        }
    }
}