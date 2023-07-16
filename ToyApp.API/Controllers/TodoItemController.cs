using Microsoft.AspNetCore.Mvc;
using ToyApp.API.Dto;
using ToyApp.API.Dto.Generics;
using ToyApp.Infrastructure.Repositories;
using ToyApp.Infrastructure.RepositoryModels;

namespace ToyApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase
{

    private readonly ILogger<TodoItemController> _logger;
    private readonly ITodoRepository _todos;

    public TodoItemController(ILogger<TodoItemController> logger, ITodoRepository todos)
    {
        _logger = logger;
        _todos = todos;
    }

    [HttpGet]
    [Route("/todo/{id}")]
    public async Task<ActionResult<TodoItemDto>> GetTodo(string id)
    {
        var model = await _todos.GetTodoItemModelByGuid(id);
        return FromModel(model);
    }

    [HttpGet]
    [Route("/todos")]
    public async Task<ActionResult<ToyCollectionResponse<TodoItemDto>>> GetTodos()
    {
        var models = await _todos.GetTodoItemModels();

        var dtos = new List<TodoItemDto>();
        models.ToList().ForEach(model => dtos.Add(FromModel(model)));
        return new ToyCollectionResponse<TodoItemDto>()
        {
            Items = dtos,
            Offset = 0
        };
    }

    [HttpPost]
    [Route("/todo")]
    public async Task<ActionResult<TodoItemDto>> CreateTodo([FromBody] TodoItemDto req)
    {
        var todo = TodoItemModel.New(req.Title, req.DueDate);
        var resp = await _todos.CreateTodoItemModel(todo);
        return FromModel(resp);
    }

    private static TodoItemDto FromModel(TodoItemModel model)
    {
        return new TodoItemDto()
        {
            Guid = model.Uuid,
            Title = model.Todo.Title,
            DueDate = model.Todo.DueDate,
        };

    }
}
