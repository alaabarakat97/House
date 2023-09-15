using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Model;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Regions.Query.GetRegionById;
public class GetRegionQueryViewModel
{
    public Guid Id { get; set; }
    public string RegionName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    //public IList<CityDto> Cities { get; set; } = new List<CityDto>();
    //public IList<ApartmentDto> Apartments { get; set; } = new List<ApartmentDto>();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Region, GetRegionQueryViewModel>();
        }
    }
}
