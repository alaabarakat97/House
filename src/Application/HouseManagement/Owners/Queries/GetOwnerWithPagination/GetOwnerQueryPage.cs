using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;

namespace House.Application.HouseManagement.Owners.Queries.GetOwnerWithPagination;
public class GetOwnerQueryPage : IRequest<PaginatedList<GetOwnerQueryViewModel>> 
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
