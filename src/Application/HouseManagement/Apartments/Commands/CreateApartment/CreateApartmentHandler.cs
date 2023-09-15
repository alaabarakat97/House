using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Apartments.Commands.CreateApartment;
public class CreateApartmentHandler : IRequestHandler<CreateApartmentCommnd, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateApartmentHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(CreateApartmentCommnd request, CancellationToken cancellationToken)
    {
        List<string> errorList = new List<string>();

        var apartment = _mapper.Map<Apartment>(request);
       
        if (apartment == null)
        {
            errorList.Add("apartment is null");
            return Result<string>.Failure(errorList, null);
        }
        _context.Apartments.Add(apartment);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(apartment.Id.ToString());
    }
}
