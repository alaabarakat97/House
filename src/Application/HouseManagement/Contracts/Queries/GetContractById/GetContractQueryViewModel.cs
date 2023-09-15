using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Contracts.Queries.GetContractById;
public class GetContractQueryViewModel
{
    public Guid OwnerId { get; set; }
    public Guid ApartmentId { get; set; }
    public int Price { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contract, GetContractQueryViewModel>();
        }
    }
}
