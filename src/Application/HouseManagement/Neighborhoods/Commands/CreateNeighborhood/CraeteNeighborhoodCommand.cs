using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Contracts.Commands.CreateContract;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Neighborhoods.Commands.CreateNeighborhood;
public class CraeteNeighborhoodCommand:IRequest<Result<string>>
{
    public Guid CityId { get; set; }
    public string NeighborhoodName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CraeteNeighborhoodCommand, Neighborhood>();
        }
    }
}
