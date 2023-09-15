using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Owners.Commands.CreateOwner;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Regions.Commands.CreateRegion;
public class CreateRegionCommand :IRequest<Result<string>>
{
    public string RegionName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateRegionCommand, Region>();
        }
    }
}
