using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Mappings;
using House.Application.Common.Models;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;

namespace House.Application.HouseManagement.Owners.Queries.GetOwnerWithPagination;
internal class GetOwnerQueryPageHandler : IRequestHandler<GetOwnerQueryPage, PaginatedList<GetOwnerQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOwnerQueryPageHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<GetOwnerQueryViewModel>> Handle(GetOwnerQueryPage request, CancellationToken cancellationToken)
    {
        var query = _context.Owners.AsQueryable();

        var paginatedList = await query.ProjectTo<GetOwnerQueryViewModel>(_mapper.ConfigurationProvider)
                                       .PaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;
    }
}
