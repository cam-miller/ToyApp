using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToyApp.Infrastructure.Persistence;
using ToyApp.Infrastructure.RepositoryModels;

namespace ToyApp.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{

    private ToyAppContext _ctx;
    private ILogger<TodoRepository> _logger;

    public TodoRepository(ToyAppContext ctx, ILogger<TodoRepository> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }

    public async Task<TodoItemModel> CreateTodoItemModel(TodoItemModel todo)
    {
        _ctx.Todos.Add(todo);
        await _ctx.SaveChangesAsync();
        return todo;
    }

    public Task<TodoItemModel> GetTodoItemModelByGuid(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItemModel> GetTodoItemModelById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TodoItemModel>> GetTodoItemModels()
    {
        return await _ctx.Todos.ToListAsync();
    }
}