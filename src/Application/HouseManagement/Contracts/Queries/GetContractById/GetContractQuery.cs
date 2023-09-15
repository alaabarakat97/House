using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Application.HouseManagement.Contracts.Queries.GetContractById;
public class GetContractQuery:IRequest<GetContractQueryViewModel>
{
    public Guid Id { get; set; }
}
