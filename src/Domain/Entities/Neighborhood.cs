using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Domain.Entities;
public class Neighborhood:BaseAuditableEntity
{
    public Guid CityId { get; set; }
    public string NeighborhoodName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    public City? City { get; set; }
    public IList<Apartment>? Apartments { get; set; } = new List<Apartment>();
}
