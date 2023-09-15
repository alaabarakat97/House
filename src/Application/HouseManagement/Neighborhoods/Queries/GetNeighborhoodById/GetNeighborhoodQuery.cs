using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoodById;
public class GetNeighborhoodQuery :IRequest<GetNeighborhoodQueryViewModel>
{
    public Guid Id { get; set; }
}
