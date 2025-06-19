using SMMS.Repositories.NghiaHT.Models;
using SMMS.Services.NghiaHT;

namespace SMMS.GraphQLAPIServices.NghiaHT.GraphQLs;

public class Mutations
{
    private readonly IServiceProviders _serviceProvider;
    public Mutations(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;

    public async Task<int> CreateRequestNghiaHt(RequestNghiaHt requestNghiaHt)
    {
        try
        {
            var result = await _serviceProvider.RequestNghiaHtService.CreateAsync(requestNghiaHt);

            return (int)result;
        }
        catch (Exception ex)
        {
        }

        return 0;
    }

    public async Task<int> UpdateRequestNghiaHt(RequestNghiaHt requestNghiaHt)
    {
        try
        {
            var result = await _serviceProvider.RequestNghiaHtService.UpdateAsync(requestNghiaHt);

            return (int)result;
        }
        catch (Exception ex)
        {

        }

        return 0;
    }

    public async Task<bool> DeleteRequestNghiaHt(int id)
    {
        try
        {
            var result = await _serviceProvider.RequestNghiaHtService.DeleteAsync(id);

            return (bool)result;
        }
        catch (Exception ex)
        {
        }

        return false;
    }
}
