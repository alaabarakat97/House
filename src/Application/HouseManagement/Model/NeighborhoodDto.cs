using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Model;
public class NeighborhoodDto
{
    public Guid CityId { get; set; }
    public string NeighborhoodName { get; set; } = string.Empty;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<NeighborhoodDto, Neighborhood>();
            CreateMap<Neighborhood, NeighborhoodDto>();
        }
    }
}
