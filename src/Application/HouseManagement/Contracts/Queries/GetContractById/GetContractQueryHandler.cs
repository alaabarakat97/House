using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Contracts.Queries.GetContractById;
public class GetContractQueryHandler : IRequestHandler<GetContractQuery, GetContractQueryViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContractQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetContractQueryViewModel> Handle(GetContractQuery request, CancellationToken cancellationToken)
    {
       var entity= await _context.Contracts
            //.Include(p=>p.Owner)
            //.Include(p=>p.Apartment)
            .SingleOrDefaultAsync(p=>p.Id == request.Id);

        Guard.Against.NotFound(request.Id, entity);

        var result = _mapper.Map<GetContractQueryViewModel>(entity);

        return result;
    }
}
