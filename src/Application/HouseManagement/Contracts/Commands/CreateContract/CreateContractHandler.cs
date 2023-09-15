using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;
using House.Domain.Entities;

namespace House.Application.HouseManagement.Contracts.Commands.CreateContract;
public class CreateContractHandler : IRequestHandler<CreateContractCommand,Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateContractHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        List<string> errorList = new List<string>();

        Contract contract = _mapper.Map<Contract>(request);

        if (contract == null)
        {
            errorList.Add("contract is null");
            return Result<string>.Failure(errorList, null);
        }
        _context.Contracts.Add(contract);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(contract.Id.ToString());
    }
}
