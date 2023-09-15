using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Commands.CreateApartment;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Contracts.Commands.CreateContract;
public class CreateContractCommand :IRequest<Result<string>>
{
    public Guid OwnerId { get; set; }
    public Guid ApartmentId { get; set; }
    public int Price { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateContractCommand, Contract>();
        }
    }
}
