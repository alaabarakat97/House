using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Regions.Commands.UpdateRegion;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Cities.Commands.UpdateCity;
public class UpdateCityCommand :IRequest<Result<string>>
{
    public Guid Id { get; set; }
    public Guid RegionId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateCityCommand, City>();
        }
    }
}
