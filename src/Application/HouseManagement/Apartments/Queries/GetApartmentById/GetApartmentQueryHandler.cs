using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
public class GetApartmentQueryHandler : IRequestHandler<GetApartmentQuery, GetApartmentQueryViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetApartmentQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context= context;  
        _mapper= mapper;    
    }
    public async Task<GetApartmentQueryViewModel> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
    {
        var entity =await _context.Apartments
            .FirstOrDefaultAsync(p=>p.Id==request.Id);

        Guard.Against.NotFound(request.Id, entity);

        var result = _mapper.Map<GetApartmentQueryViewModel>(entity);

        return result;
    }
}
