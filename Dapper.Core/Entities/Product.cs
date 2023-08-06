
namespace Dapper.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public double Rate { get; set; }
    public DateTime AddedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}