using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToyApp.Core;
using ToyApp.Infrastructure.RepositoryModels;

namespace ToyApp.Infrastructure.Persistence.ModelConfigurations;

public class TodoConfiguration : IEntityTypeConfiguration<TodoItemModel>
{
    public void Configure(EntityTypeBuilder<TodoItemModel> builder)
    {
        builder.ToTable("todo_item");
        builder.OwnsOne(td => td.Todo);
    }
}