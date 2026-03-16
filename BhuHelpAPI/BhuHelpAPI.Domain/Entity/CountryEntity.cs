namespace BhuHelpAPI.Domain.Entity;

[Table(CommonFields.Country)]
public class CountryEntity : BaseEntity
{
    public string? Name { get; set; }
    public virtual ICollection<StateEntity> States { get; set; }
}