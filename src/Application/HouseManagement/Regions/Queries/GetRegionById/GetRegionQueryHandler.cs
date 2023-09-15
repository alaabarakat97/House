using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Regions.Query.GetRegionById;
public class GetRegionQueryHandler : IRequestHandler<GetRegionQuery, GetRegionQueryViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRegionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetRegionQueryViewModel> Handle(GetRegionQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Regions
            .FirstOrDefaultAsync(p => p.Id == request.Id);

        if (entity != null)
        {
            await _context.Entry<Region>(entity).Collection(x => x.Apartments).LoadAsync();
            await _context.Entry<Region>(entity).Collection(x => x.Cities).LoadAsync();
            await _context.Entry<Region>(entity).Collection(x => x.Owners).LoadAsync();
        }

        Guard.Against.NotFound(request.Id, entity);

        var result = _mapper.Map<GetRegionQueryViewModel>(entity);

        return result;
    }
}
