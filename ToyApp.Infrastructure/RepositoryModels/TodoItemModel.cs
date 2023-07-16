using Microsoft.EntityFrameworkCore;
using ToyApp.Core;

namespace ToyApp.Infrastructure.RepositoryModels;

[PrimaryKey(nameof(Id))]
public class TodoItemModel : RepositoryEntity
{
    public required TodoItem Todo { get; set; }

    public static TodoItemModel New(string title, DateTime dueDate)
    {
        var item = new TodoItemModel()
        {
            Todo = new TodoItem(title, dueDate),
            Uuid = Guid.NewGuid().ToString(),
        };
        return item;
    }

}