using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ToyApp.Infrastructure.RepositoryModels;

namespace ToyApp.Infrastructure.Persistence;

public class ToyAppContext : DbContext
{
    public DbSet<TodoItemModel> Todos => Set<TodoItemModel>();

    public string DbPath { get; }
    public ToyAppContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "toyapp.db");
    }

    // pretty lazy hack but it works.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


    // override that handles updating auditables and theoretically pushing events
    // yoinked from https://github.com/arbems/Clean-Architecture-Solution/blob/main/src/Infrastructure/Persistence/ApplicationDbContext.cs
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<Auditable>())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    // irl we would have the actual user here.
                    entry.Entity.Update("ThisUserIdWouldComeFromRequestContext");
                    break;
            }
        }
        var result = 0;
        try
        {
            result = await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Update the values of the entity that failed to save from the store (https://docs.microsoft.com/es-es/ef/ef6/saving/concurrency)
            ex.Entries.Single().Reload();
        }
        //await DispatchEvents(events); // doesn't happen yet.
        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }


}