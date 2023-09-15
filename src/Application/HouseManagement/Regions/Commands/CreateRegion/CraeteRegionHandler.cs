using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Regions.Commands.CreateRegion;
public class CraeteRegionHandler : IRequestHandler<CreateRegionCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CraeteRegionHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        List<string> errorList = new List<string>();

        var isRegionExisted = await _context.Regions
           .AnyAsync(p => p.LicenseId == request.LicenseId);

        if (isRegionExisted)
        {
            errorList.Add("License is duplicated");
            return Result<string>.Failure(errorList, null);
        }

        Region region = _mapper.Map<Region>(request);

        if (region == null)
        {
            errorList.Add("region is null");
            return Result<string>.Failure(errorList, null);
        }
        _context.Regions.Add(region);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(region.Id.ToString());
    }
}
