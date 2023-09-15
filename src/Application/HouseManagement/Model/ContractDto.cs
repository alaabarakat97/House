using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Model;
public class ContractDto
{
    public Guid OwnerId { get; set; }
    public Guid ApartmentId { get; set; }
    public int Price { get; set; }
    public DateTimeOffset Create  { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ContractDto, Contract>();
            CreateMap<Contract, ContractDto>();
        }
    }
}
