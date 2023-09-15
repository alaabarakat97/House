using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;
using House.Application.HouseManagement.Owners.Commands.CreateOwner;

namespace House.Application.HouseManagement.Owners.Commands.UpdateOwner;
public class UpdateOwnerHandler : IRequestHandler<UpdateOwnerCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateOwnerHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var errorList = new List<string>();

        var entity = await _context.Owners
           .Include(i => i.Apartments)
           .FirstOrDefaultAsync(p => p.Id == request.Id);

        if (entity == null)
        {
            errorList.Add("The request is not saved");
            return Result<string>.Failure(errorList, null);
        }

        _mapper.Map(request, entity);

        entity.SetOwnerSequence();

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(entity.Id.ToString());
    }
}
