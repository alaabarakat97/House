using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Model;
public class CityDto
{
    public Guid RegionId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public IList<NeighborhoodDto> Neighborhoods { get; set; } = new List<NeighborhoodDto>();
    public IList<OwnerDto> Owners { get; set; } = new List<OwnerDto>();
    public IList<ApartmentDto> Apartments { get; set; } = new List<ApartmentDto>();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CityDto, City>();
            CreateMap<City, CityDto>();
        }
    }
}
