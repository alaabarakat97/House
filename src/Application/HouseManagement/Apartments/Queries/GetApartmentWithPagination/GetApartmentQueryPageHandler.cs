using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Mappings;
using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Enums;

namespace House.Application.HouseManagement.Apartments.Queries.GetApartmentWithPagination;
public class GetApartmentQueryPageHandler : IRequestHandler<GetApartmentQueryPage, PaginatedList<GetApartmentQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetApartmentQueryPageHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<GetApartmentQueryViewModel>> Handle(GetApartmentQueryPage request, CancellationToken cancellationToken)
    {
        var queries = _context.Apartments.Where(p=>p.HouseStatus == HouseStatus.Active);

        if (request.PriceFilter.HasValue)
        {
            switch(request.PriceFilter.Value) {
                case PriceFilter.Hight: queries = queries.OrderBy(x => x.Price);break;
                case PriceFilter.Less: queries = queries.OrderByDescending(x => x.Price);break;
                default:break;
            }
        }
        //if (request.SubmissionDate.HasValue)
        //    query = query.Where(req => req.SubmissionDate >= request.SubmissionDate);

        if (!string.IsNullOrEmpty(request.NeighborhoodId.ToString()))
            queries = queries.Where(req => req.NeighborhoodId == request.NeighborhoodId);

        if (!string.IsNullOrEmpty(request.CityId.ToString()))
            queries = queries.Where(req => req.CityId == request.CityId);

        if (!string.IsNullOrEmpty(request.OwnerId.ToString()))
            queries = queries.Where(req => req.OwnerId == request.OwnerId);

        if (request.HouseType.HasValue)
            queries = queries.Where(req => req.HouseType == request.HouseType);

        var paginatedList = await queries.ProjectTo<GetApartmentQueryViewModel>(_mapper.ConfigurationProvider)
                                       .PaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;
    }
}
