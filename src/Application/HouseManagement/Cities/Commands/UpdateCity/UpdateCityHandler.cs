﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Interfaces;
using House.Application.Common.Models;

namespace House.Application.HouseManagement.Cities.Commands.UpdateCity;
public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UpdateCityHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<string>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var errorList = new List<string>();

        var entity = await _context.Cities
           .FirstOrDefaultAsync(p => p.Id == request.Id);

        if (entity == null)
        {
            errorList.Add("The request is not updated!");
            return Result<string>.Failure(errorList, null);
        }

        Guard.Against.NotFound(request.Id, entity);

        _mapper.Map(request, entity);


        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(entity.Id.ToString());
    }
}
