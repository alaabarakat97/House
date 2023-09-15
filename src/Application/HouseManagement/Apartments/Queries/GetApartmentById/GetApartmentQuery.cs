using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
public class GetApartmentQuery : IRequest<GetApartmentQueryViewModel>
{
    public Guid Id { get; set; }
}
