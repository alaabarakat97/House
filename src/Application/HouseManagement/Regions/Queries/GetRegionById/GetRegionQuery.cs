using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;

namespace House.Application.HouseManagement.Regions.Query.GetRegionById;
public class GetRegionQuery : IRequest<GetRegionQueryViewModel>
{
    public Guid Id { get; set; }
}
