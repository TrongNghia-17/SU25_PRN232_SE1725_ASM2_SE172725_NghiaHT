using SMMS.Repositories.NghiaHT.ModelExtensions;
using SMMS.Repositories.NghiaHT.Models;
using SMMS.Services.NghiaHT;

namespace SMMS.GraphQLAPIServices.NghiaHT.GraphQLs;

public class Queries
{
    private readonly IServiceProviders _serviceProvider;
    public Queries(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;

    public async Task<List<RequestNghiaHt>> GetRequestNghiaHt()
    {
        try
        {
            var result = await _serviceProvider.RequestNghiaHtService.GetAllAsync();
            return result ??= new List<RequestNghiaHt>();
        }
        catch (Exception ex)
        {
            return new List<RequestNghiaHt>();
        }
    }

    public async Task<RequestNghiaHt> GetRequestNghiaHtById(int id)
    {
        try
        {
            var result = await _serviceProvider.RequestNghiaHtService.GetByIdAsync(id);
            return result ??= new RequestNghiaHt();
        }
        catch (Exception ex)
        {
            return new RequestNghiaHt();
        }
    }

    public async Task<PaginationResult<List<RequestNghiaHt>>> SearchWithPagingAsync(SearchRequestNghiaHt request)
    {
        try
        {
            var result = await _serviceProvider.RequestNghiaHtService.SearchWithPagingAsync(request);

            return result ?? new PaginationResult<List<RequestNghiaHt>>();
        }
        catch (Exception ex)
        {
        }

        return new PaginationResult<List<RequestNghiaHt>>();
    }
}
