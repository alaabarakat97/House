using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Regions.Query.GetRegionById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoodById;
public class GetNeighborhoodQueryViewModel
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string NeighborhoodName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Neighborhood, GetNeighborhoodQueryViewModel>();
        }
    }
}
