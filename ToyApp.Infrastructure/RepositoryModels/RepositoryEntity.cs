using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToyApp.Infrastructure.RepositoryModels;

[Index(nameof(Uuid))]
public abstract class RepositoryEntity : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Uuid { get; set; }
}