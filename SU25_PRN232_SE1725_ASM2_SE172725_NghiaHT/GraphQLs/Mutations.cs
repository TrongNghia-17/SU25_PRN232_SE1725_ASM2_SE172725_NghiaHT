using SMMS.GraphQLAPIServices.NghiaHT.Models;
using SMMS.Repositories.NghiaHT.Models;
using SMMS.Services.NghiaHT;

namespace SMMS.GraphQLAPIServices.NghiaHT.GraphQLs;

public class Mutations
{
    private readonly IServiceProviders _serviceProvider;
    public Mutations(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;


    public async Task<int> CreateRequestNghiaHt(CreateRequestNghiaHtInput requestNghiaHtInput)
    {
        try
        {
            //var result = await _serviceProvider.RequestNghiaHtService.CreateAsync(requestNghiaHtInput);
            var request = new RequestNghiaHt
            {
                MedicationName = requestNghiaHtInput.MedicationName,
                Dosage = requestNghiaHtInput.Dosage,
                Frequency = requestNghiaHtInput.Frequency,
                Reason = requestNghiaHtInput.Reason,
                Instruction = requestNghiaHtInput.Instruction,
                Quantity = requestNghiaHtInput.Quantity,
                Strength = requestNghiaHtInput.Strength,
                Indications = requestNghiaHtInput.Indications,
                Contraindications = requestNghiaHtInput.Contraindications,
                StartDate = requestNghiaHtInput.StartDate,
                CreatedDate = requestNghiaHtInput.CreatedDate,
                IsApproved = requestNghiaHtInput.IsApproved,
                MedicationCategoryQuanTnid = requestNghiaHtInput.MedicationCategoryQuanTnid
            };

            var result = await _serviceProvider.RequestNghiaHtService.CreateAsync(request);
            return result;
        }
        catch (Exception ex)
        {
        }

        return 0;
    }

    public async Task<int> UpdateRequestNghiaHt(RequestNghiaHt request)
    {
        try
        {          
            var result = await _serviceProvider.RequestNghiaHtService.UpdateAsync(request);

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

            return result;
        }
        catch (Exception ex)
        {
        }

        return false;
    }
}
