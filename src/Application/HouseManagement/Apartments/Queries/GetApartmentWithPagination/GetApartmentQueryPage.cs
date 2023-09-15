using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Enums;

namespace House.Application.HouseManagement.Apartments.Queries.GetApartmentWithPagination;
public class GetApartmentQueryPage : IRequest<PaginatedList<GetApartmentQueryViewModel>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public Guid? NeighborhoodId { get; init; } = null;
    public Guid? CityId { get; init; } = null;
    public Guid? OwnerId { get; init; } = null;
    public PriceFilter? PriceFilter { get; init; }
    public HouseType? HouseType { get; init; }
}
