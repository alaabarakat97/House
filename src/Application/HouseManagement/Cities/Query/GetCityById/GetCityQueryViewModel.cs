using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
using House.Application.HouseManagement.Model;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Cities.Query.GetCityById;
public class GetCityQueryViewModel
{
    public Guid Id { get; set; }
    public Guid RegionId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string LicenseId { get; set; } = string.Empty;
    //public IList<NeighborhoodDto> Neighborhoods { get; set; } = new List<NeighborhoodDto>();
    //public IList<OwnerDto> Owners { get; set; } = new List<OwnerDto>();
    //public IList<ApartmentDto> Apartments { get; set; } = new List<ApartmentDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<City, GetCityQueryViewModel>();
        }
    }
}
