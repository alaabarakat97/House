using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Owners.Queries.GetOwnerById;
public class GetOwnerQueryHandler : IRequestHandler<GetOwnerQuery, GetOwnerQueryViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOwnerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetOwnerQueryViewModel> Handle(GetOwnerQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Owners
            .FirstOrDefaultAsync(p => p.Id == request.Id);

        if (entity != null)
        {
            await _context.Entry<Owner>(entity).Collection(x => x.Apartments).LoadAsync();
        }

        Guard.Against.NotFound(request.Id, entity);

        var result = _mapper.Map<GetOwnerQueryViewModel>(entity);

        return result;
    }
}
