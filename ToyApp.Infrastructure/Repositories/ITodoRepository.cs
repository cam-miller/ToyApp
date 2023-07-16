using ToyApp.Infrastructure.RepositoryModels;

namespace ToyApp.Infrastructure.Repositories;

public interface ITodoRepository
{
    public Task<IEnumerable<TodoItemModel>> GetTodoItemModels();
    public Task<TodoItemModel> CreateTodoItemModel(TodoItemModel todo);
    public Task<TodoItemModel> GetTodoItemModelById(int id);
    public Task<TodoItemModel> GetTodoItemModelByGuid(string uuid);
}