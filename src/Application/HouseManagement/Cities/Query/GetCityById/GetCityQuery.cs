using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Application.HouseManagement.Cities.Query.GetCityById;
public class GetCityQuery :IRequest<GetCityQueryViewModel>
{
    public Guid Id { get; set; }
}
