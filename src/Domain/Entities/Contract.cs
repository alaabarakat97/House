namespace House.Domain.Entities;
public class Contract : BaseAuditableEntity
{
    public Guid OwnerId { get; set; }
    public Guid ApartmentId { get; set; }
    public int Price { get; set; }
    public virtual Owner? Owner { get; set; }
    public virtual Apartment? Apartment { get; set; }

}
