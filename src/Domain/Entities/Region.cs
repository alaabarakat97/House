using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Domain.Entities;
public class Region : BaseAuditableEntity
{
    public string RegionName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    public IList<City> Cities { get; set; } = new List<City>();
    public IList<Apartment> Apartments { get; set; } = new List<Apartment>();
    public IList<Owner> Owners { get; set; } = new List<Owner>();
}
