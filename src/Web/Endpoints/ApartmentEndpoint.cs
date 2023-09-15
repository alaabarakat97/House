using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Commands.CreateApartment;
using House.Application.HouseManagement.Apartments.Commands.UpdateApartment;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentWithPagination;
using House.Application.HouseManagement.Owners.Commands.UpdateOwner;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;

namespace House.Web.Endpoints;

public class Apartment : EndpointGroupBase
{
    public Apartment()
    {
            
    }
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CraeteApartment)
            .MapPut(UpdateApartment, "updateApartment")
            .MapGet(GetApartmentItem, "getApartmentItem")
            .MapGet(GetApartmentPagination, "GetApartmentPagination");
    }
    public async Task<Result<string>> CraeteApartment(ISender sender, CreateApartmentCommnd command)
    {
        var apartment = await sender.Send(command);

        if (!apartment.Succeeded)
        {
            return Result<string>.Failure(apartment.Errors, null);
        }

        return Result<string>.Success(apartment.Value ?? string.Empty);
    }

    public async Task<Result<string>> UpdateApartment(ISender sender, Guid id, UpdateApartmentCommand command)
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

    public async Task<GetApartmentQueryViewModel> GetApartmentItem(ISender sender, [AsParameters] GetApartmentQuery apartmentQuery)
    {
        return await sender.Send(new GetApartmentQuery { Id = apartmentQuery.Id });
    } 
    public async Task<PaginatedList<GetApartmentQueryViewModel>> GetApartmentPagination(ISender sender, [AsParameters] GetApartmentQueryPage query)
    {
        return await sender.Send(query);
    }
}
