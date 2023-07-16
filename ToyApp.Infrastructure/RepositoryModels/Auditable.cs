using Microsoft.EntityFrameworkCore;

namespace ToyApp.Infrastructure.RepositoryModels;
public abstract class Auditable
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public void Update(string actorName)
    {
        UpdatedBy = actorName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Create(string actorName)
    {
        CreatedBy = actorName;
        CreatedAt = DateTime.UtcNow;

    }
}