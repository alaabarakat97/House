using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Cities.Query.GetCityById;
public class GetCityQueryHandler : IRequestHandler<GetCityQuery, GetCityQueryViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetCityQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetCityQueryViewModel> Handle(GetCityQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cities
            .FirstOrDefaultAsync(p => p.Id == request.Id);

        if (entity != null)
        {
            await _context.Entry<City>(entity).Collection(x => x.Owners).LoadAsync();
            await _context.Entry<City>(entity).Collection(x => x.Apartments).LoadAsync();
            await _context.Entry<City>(entity).Collection(x => x.Neighborhoods).LoadAsync();
        }

        Guard.Against.NotFound(request.Id, entity);

        var result = _mapper.Map<GetCityQueryViewModel>(entity);

        return result;
    }
}
