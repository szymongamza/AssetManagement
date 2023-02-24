using System.ComponentModel.DataAnnotations;
using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Maintenance : BaseAuditableEntity
{
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public string? Description { get; set; }
    public int AssetId { get; set; }
    public Asset Product { get; set; } = null!;
}