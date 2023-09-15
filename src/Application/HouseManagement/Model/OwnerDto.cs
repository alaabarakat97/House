using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Model;
public class OwnerDto
{
    public Guid CityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OwnerDto, Owner>();
            CreateMap<Owner, OwnerDto>();
        }
    }
}
