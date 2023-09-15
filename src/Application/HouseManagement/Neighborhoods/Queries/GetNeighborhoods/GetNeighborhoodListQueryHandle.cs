using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.HouseManagement.Cities.Query.GetCityById;
using House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoodById;

namespace House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoods;
public class GetNeighborhoodListQueryHandle : IRequestHandler<GetNeighborhoodListQuery, List<GetNeighborhoodQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNeighborhoodListQueryHandle(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetNeighborhoodQueryViewModel>> Handle(GetNeighborhoodListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Neighborhoods
            .Where(p => p.CityId == request.CityId)
            .ToListAsync();

        Guard.Against.NotFound(request.CityId, query);

        var result = _mapper.Map<List<GetNeighborhoodQueryViewModel>>(query);

        return result; throw new NotImplementedException();
    }
}
