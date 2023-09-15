using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Commands.UpdateApartment;
using House.Application.HouseManagement.Contracts.Commands.CreateContract;
using House.Application.HouseManagement.Contracts.Queries.GetContractById;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Application.HouseManagement.Owners.Queries.GetOwnerWithPagination;
using House.Application.HouseManagement.Regions.Commands.CreateRegion;
using House.Application.HouseManagement.Regions.Commands.UpdateRegion;
using House.Application.HouseManagement.Regions.Queries.GetRegions;
using House.Application.HouseManagement.Regions.Query.GetRegionById;

namespace House.Web.Endpoints;

public class Region : EndpointGroupBase
{
    public Region()
    {

    }
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateRegion)
            .MapGet(GetRegionItem, "getRegionItem")
            .MapGet(GetRegions, "getRegions")
            .MapPut(UpdateRegion, "updateRegion");
    }
    public async Task<Result<string>> CreateRegion(ISender sender, CreateRegionCommand command)
    {
        var region = await sender.Send(command);

        if (!region.Succeeded)
        {
            return Result<string>.Failure(region.Errors, null);
        }

        return Result<string>.Success(region.Value ?? string.Empty);
    }

    public async Task<GetRegionQueryViewModel> GetRegionItem(ISender sender, [AsParameters] GetRegionQuery regionQuery)
    {
        return await sender.Send(new GetRegionQuery { Id = regionQuery.Id });
    }

    public async Task<List<GetRegionQueryViewModel>> GetRegions(ISender sender, [AsParameters] GetRegionQueryList query)
    {
        
        return await sender.Send(query);
    }

    public async Task<Result<string>> UpdateRegion(ISender sender, Guid id, UpdateRegionCommand command)
    {
        if (id != command.Id)
            return (Result<string>)Results.BadRequest();

        var result = await sender.Send(command);
        if (result.Value == null || !result.Succeeded)
        {
            return Result<string>.Failure(result.Errors, null);
        }
        return Result<string>.Success(result.Value);
    }
}
