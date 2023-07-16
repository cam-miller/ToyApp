using ToyApp.Infrastructure.RepositoryModels;

namespace ToyApp.API.Dto;

public class TodoItemDto
{
    // saves me from needing a different dto for command/query.
    public string? Guid { get; set; }
    public required string Title { get; set; }
    public required DateTime DueDate { get; set; }

    public TodoItemDto() { }


}