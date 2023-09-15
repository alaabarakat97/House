using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Contracts.Queries.GetContractById;

namespace House.Application.HouseManagement.Contracts.Queries.GetContractWithPaginaion;
public class GetContractQueryPage : IRequest<PaginatedList<GetContractQueryViewModel>> 
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
