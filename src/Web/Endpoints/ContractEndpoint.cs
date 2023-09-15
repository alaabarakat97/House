using House.Application.Common.Models;
using House.Application.HouseManagement.Apartments.Commands.CreateApartment;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
using House.Application.HouseManagement.Apartments.Queries.GetApartmentWithPagination;
using House.Application.HouseManagement.Contracts.Commands.CreateContract;
using House.Application.HouseManagement.Contracts.Queries.GetContractById;
using House.Application.HouseManagement.Contracts.Queries.GetContractWithPaginaion;

namespace House.Web.Endpoints;

public class ContractEndpoint : EndpointGroupBase
{
    public ContractEndpoint()
    {
            
    }
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateContract)
            .MapGet(GetContractItem, "getContractItem")
            .MapGet(GetContractPagination, "GetContractPagination");
    }
    public async Task<Result<string>> CreateContract(ISender sender, CreateContractCommand command)
    {
        var contract = await sender.Send(command);

        if (!contract.Succeeded)
        {
            return Result<string>.Failure(contract.Errors, null);
        }

        return Result<string>.Success(contract.Value ?? string.Empty);
    }

    public async Task<GetContractQueryViewModel> GetContractItem(ISender sender, [AsParameters] GetContractQuery contractQuery)
    {
        return await sender.Send(new GetContractQuery { Id = contractQuery.Id });
    }
    public async Task<PaginatedList<GetContractQueryViewModel>> GetContractPagination(ISender sender, [AsParameters] GetContractQueryPage query)
    {
        return await sender.Send(query);
    }
}
