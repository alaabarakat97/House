using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Commands.CreateApartment;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Cities.Commands.CreateCity;
public class CreateCityCommand : IRequest<Result<string>>
{
    public Guid RegionId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateCityCommand, City>();
        }
    }
}
