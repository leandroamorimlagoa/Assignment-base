namespace Assignment.Domain.Entities;
public class Country : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<City> Cities { get; set; } = new List<City>();
}
