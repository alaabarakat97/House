using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Domain.Entities;
public class Owner : BaseAuditableEntity
{
    public Guid CityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public City? City { get; set; }
    public  IList<Apartment> Apartments { get; set; } = new List<Apartment>();
    public IList<Contract> Contracts { get; set; } = new List<Contract>();
    
}
