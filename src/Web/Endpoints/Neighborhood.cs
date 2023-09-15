using House.Application.Common.Models;
using House.Application.HouseManagement.Cities.Commands.UpdateCity;
using House.Application.HouseManagement.Cities.Query.GetCitiesByRegionId;
using House.Application.HouseManagement.Cities.Query.GetCityById;
using House.Application.HouseManagement.Contracts.Commands.CreateContract;
using House.Application.HouseManagement.Neighborhoods.Commands.CreateNeighborhood;
using House.Application.HouseManagement.Neighborhoods.Commands.UpdateNeighborhood;
using House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoodById;
using House.Application.HouseManagement.Neighborhoods.Queries.GetNeighborhoods;

namespace House.Web.Endpoints;

public class Neighborhood:EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
          .MapPost(CreateNeighborhood)
          .MapGet(GetNeighborhoodItem, "getNeighborhoodItem")
          .MapGet(GetNeighborhoods, "getNeighborhoods")
          .MapPut(UpdateNeighborhood, "updateNeighborhood");
    }

    public async Task<Result<string>> CreateNeighborhood(ISender sender, CraeteNeighborhoodCommand command)
    {
        var neighborhood = await sender.Send(command);

        if (!neighborhood.Succeeded)
        {
            return Result<string>.Failure(neighborhood.Errors, null);
        }

        return Result<string>.Success(neighborhood.Value ?? string.Empty);
    }
    public async Task<Result<string>> UpdateNeighborhood(ISender sender, Guid id, UpdateNeighborhoodCommand command)
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
    public async Task<GetNeighborhoodQueryViewModel> GetNeighborhoodItem(ISender sender, [AsParameters] GetNeighborhoodQuery neighborhoodQuery)
    {
        return await sender.Send(new GetNeighborhoodQuery { Id = neighborhoodQuery.Id });
    }
    public async Task<List<GetNeighborhoodQueryViewModel>> GetNeighborhoods(ISender sender, [AsParameters] GetNeighborhoodListQuery query)
    {

        return await sender.Send(query);
    }
}
