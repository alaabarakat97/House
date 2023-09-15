using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace House.Domain.Entities;
public class Apartment: BaseAuditableEntity
{
    public Guid OwnerId { get; set; }
    public Guid? NeighborhoodId { get; set; } = null;
    public Guid CityId { get; set; }
    public int Sequence { get; set; }
    public int ApartmentNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string? Description { get; set; } = null;
    public int FloorNumber { get; set; }
    public int NumberRoom { get; set; }
    public string DescriptionLocation { get; set; } = string.Empty;
    public HouseStatus HouseStatus { get; set; }
    public HouseType HouseType { get; set; }
    public virtual Owner? Owner { get; set; }
    public virtual Neighborhood? Neighborhood { get; set; } = null;
    public virtual City? City { get; set; }
    public IList<Contract> Contracts { get; set; } = new List<Contract>();
    public void UpdateSequence(int _sequence)
    {
        Sequence = _sequence;
    }
}
