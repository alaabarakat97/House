using House.Application.Common.Models;
using House.Application.HouseManagement.Cities.Commands.CreateCity;
using House.Application.HouseManagement.Cities.Commands.UpdateCity;
using House.Application.HouseManagement.Cities.Query.GetCitiesByRegionId;
using House.Application.HouseManagement.Cities.Query.GetCityById;
using House.Application.HouseManagement.Contracts.Commands.CreateContract;
using House.Application.HouseManagement.Contracts.Queries.GetContractById;
using House.Application.HouseManagement.Regions.Commands.UpdateRegion;
using House.Application.HouseManagement.Regions.Queries.GetRegions;
using House.Application.HouseManagement.Regions.Query.GetRegionById;

namespace House.Web.Endpoints;

public class City : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateCity)
            .MapGet(GetCityItem, "getCityItem")
            .MapGet(GetCities, "getCities")
            .MapPut(UpdateCity, "updateCity");
    }
    public async Task<Result<string>> CreateCity(ISender sender, CreateCityCommand command)
    {
        var city = await sender.Send(command);

        if (!city.Succeeded)
        {
            return Result<string>.Failure(city.Errors, null);
        }

        return Result<string>.Success(city.Value ?? string.Empty);
    }
    public async Task<GetCityQueryViewModel> GetCityItem(ISender sender, [AsParameters] GetCityQuery cityQuery)
    {
        return await sender.Send(new GetCityQuery { Id = cityQuery.Id });
    }
    public async Task<List<GetCityQueryViewModel>> GetCities(ISender sender, [AsParameters] GetCitiesQuery query)
    {

        return await sender.Send(query);
    }

    public async Task<Result<string>> UpdateCity(ISender sender, Guid id, UpdateCityCommand command)
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
