using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Mappings;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Application.HouseManagement.Regions.Query.GetRegionById;

namespace House.Application.HouseManagement.Regions.Queries.GetRegions;
public class GetRegionsQueryHandler : IRequestHandler<GetRegionQueryList, List<GetRegionQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRegionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetRegionQueryViewModel>> Handle(GetRegionQueryList request, CancellationToken cancellationToken)
    {
        var query =await _context.Regions
            .Include(p=>p.Owners)
            .Include(p=>p.Apartments)
            .Include(p=>p.Cities)
            .ToListAsync();

        var result = _mapper.Map<List<GetRegionQueryViewModel>>(query);

        return result;
        
    }
}
