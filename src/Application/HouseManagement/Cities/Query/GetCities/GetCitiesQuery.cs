using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Cities.Query.GetCityById;

namespace House.Application.HouseManagement.Cities.Query.GetCitiesByRegionId;
public class GetCitiesQuery : IRequest<List<GetCityQueryViewModel>>
{
    public Guid ReginId { get; set; }
}
