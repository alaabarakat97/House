using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Application.HouseManagement.Owners.Queries.GetOwnerById;
public class GetOwnerQuery : IRequest<GetOwnerQueryViewModel>
{
    public Guid Id { get; set; }
}
