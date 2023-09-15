using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoodById;
public class GetNeighborhoodHandler : IRequestHandler<GetNeighborhoodQuery, GetNeighborhoodQueryViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNeighborhoodHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetNeighborhoodQueryViewModel> Handle(GetNeighborhoodQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Neighborhoods
            .FirstOrDefaultAsync(p => p.Id == request.Id);

        //if (query != null)
        //{
        //    await _context.Entry<Neighborhood>(query).Collection(x => x.Apartments).LoadAsync();
        //}

        Guard.Against.NotFound(request.Id, query);

        var result = _mapper.Map<GetNeighborhoodQueryViewModel>(query);

        return result;
    }
}
