using House.Application.Common.Models;
using House.Application.HouseManagement.Owners.Commands.CreateOwner;
using House.Application.HouseManagement.Owners.Commands.UpdateOwner;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Application.HouseManagement.Owners.Queries.GetOwnerWithPagination;

namespace House.Web.Endpoints;

public class OwnerEndpoint : EndpointGroupBase
{
    public OwnerEndpoint()
    {

    }
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateOwner)
            .MapGet(GetOwnerItem, "getOwnerItem")
            .MapGet(GetOwnertemsWithPagination, "GetOwnertemsWithPagination")
            .MapPut(UpdateOwner, "updateOwner");
    }
    public async Task<Result<string>> CreateOwner(ISender sender, CreateOwnerCommand command)
    {
        var owner = await sender.Send(command);

        if (!owner.Succeeded)
        {
            return Result<string>.Failure(owner.Errors, null);
        }

        return Result<string>.Success(owner.Value ?? string.Empty);
    }

    public async Task<GetOwnerQueryViewModel> GetOwnerItem(ISender sender, [AsParameters] GetOwnerQuery ownerQuery)
    {
        return await sender.Send(new GetOwnerQuery() { Id = ownerQuery.Id });
    }

    public async Task<PaginatedList<GetOwnerQueryViewModel>> GetOwnertemsWithPagination(ISender sender, [AsParameters] GetOwnerQueryPage query)
    {
        return await sender.Send(query);
    }
    public async Task<Result<string>> UpdateOwner(ISender sender, Guid id, UpdateOwnerCommand command)
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
