using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Commands.UpdateApartment;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Regions.Commands.UpdateRegion;
public class UpdateRegionCommand : IRequest<Result<string>>
{
    public Guid Id { get; set; }
    public string RegionName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRegionCommand, Region>();
        }
    }
}
