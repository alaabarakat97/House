using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.HouseManagement.Cities.Query.GetCityById;
using House.Application.HouseManagement.Regions.Query.GetRegionById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Cities.Query.GetCitiesByRegionId;
public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<GetCityQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetCitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetCityQueryViewModel>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Cities
            .Where(p => p.RegionId == request.ReginId)
            .Include(p => p.Owners)
            .Include(p => p.Apartments)
            .ToListAsync();

        Guard.Against.NotFound(request.ReginId, query);

        var result = _mapper.Map<List<GetCityQueryViewModel>>(query);

        return result;
    }
}
