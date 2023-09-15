using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Domain.Entities;
public class City:BaseAuditableEntity
{
    public Guid RegionId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    public Region? Region { get; set; }
    public IList<Neighborhood> Neighborhoods { get; set; } = new List<Neighborhood>();
    public IList<Owner> Owners { get; set; } = new List<Owner>();
    public IList<Apartment> Apartments { get; set; } = new List<Apartment>();
}
