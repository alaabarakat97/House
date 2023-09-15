using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Mappings;
using House.Application.Common.Models;
using House.Application.HouseManagement.Contracts.Queries.GetContractById;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Application.HouseManagement.Owners.Queries.GetOwnerWithPagination;

namespace House.Application.HouseManagement.Contracts.Queries.GetContractWithPaginaion;
public class GetContractQueryPageHandler : IRequestHandler<GetContractQueryPage, PaginatedList<GetContractQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContractQueryPageHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<GetContractQueryViewModel>> Handle(GetContractQueryPage request, CancellationToken cancellationToken)
    {
        var query = _context.Contracts.AsQueryable();

        var paginatedList = await query.ProjectTo<GetContractQueryViewModel>(_mapper.ConfigurationProvider)
                                       .PaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;
    }
}
