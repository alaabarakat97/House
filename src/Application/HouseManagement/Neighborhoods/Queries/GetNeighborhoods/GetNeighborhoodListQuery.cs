using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoodById;

namespace House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoods;
public class GetNeighborhoodListQuery : IRequest<List<GetNeighborhoodQueryViewModel>>
{
    public Guid CityId { get; set; }
}
