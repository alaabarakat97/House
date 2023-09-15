using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Exceptions;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Owners.Commands.CreateOwner;
public class CreateOwnerHandler : IRequestHandler<CreateOwnerCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateOwnerHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        List<string> errorList = new List<string>();



        Owner owner = _mapper.Map<Owner>(request);

        owner.SetOwnerSequence();

        if (owner == null)
        {
            errorList.Add("Owner is null");
            return Result<string>.Failure(errorList, null);
        }
        _context.Owners.Add(owner);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(owner.Id.ToString());
    }
}
