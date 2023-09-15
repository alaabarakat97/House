using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Cities.Commands.CreateCity;
public class CreateCityHandler : IRequestHandler<CreateCityCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateCityHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        List<string> errorList = new List<string>();

        var isCityExisted = await _context.Cities
           .AnyAsync(p => p.LicenseId == request.LicenseId);

        if (isCityExisted)
        {
            errorList.Add("License is duplicated");
            return Result<string>.Failure(errorList, null);
        }
        var city = _mapper.Map<City>(request);

        if (city == null)
        {
            errorList.Add("City is null");
            return Result<string>.Failure(errorList, null);
        }
        _context.Cities.Add(city);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(city.Id.ToString());
    }
}
