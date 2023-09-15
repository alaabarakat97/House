using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Neighborhoods.Commands.CreateNeighborhood;
public class CraeteNeighborhoodHandler : IRequestHandler<CraeteNeighborhoodCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CraeteNeighborhoodHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(CraeteNeighborhoodCommand request, CancellationToken cancellationToken)
    {
        List<string> errorList = new List<string>();

        var isNeighborhoodExisted = await _context.Neighborhoods
          .AnyAsync(p => p.LicenseId == request.LicenseId);

        if (isNeighborhoodExisted)
        {
            errorList.Add("License is duplicated");
            return Result<string>.Failure(errorList, null);
        }

        Neighborhood neighborhood = _mapper.Map<Neighborhood>(request);

        if (neighborhood == null)
        {
            errorList.Add("Neighborhood is null");
            return Result<string>.Failure(errorList, null);
        }
        _context.Neighborhoods.Add(neighborhood);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(neighborhood.Id.ToString());
    }
}
