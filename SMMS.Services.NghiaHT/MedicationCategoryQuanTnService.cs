using SMMS.Repositories.NghiaHT;
using SMMS.Repositories.NghiaHT.Models;

namespace SMMS.Services.NghiaHT;

public class MedicationCategoryQuanTnService
{
    //private readonly MedicationCategoryQuanTnRepository _medicationQuanTnRepository;
    private IUnitOfWork _unitOfWork;
    public MedicationCategoryQuanTnService()
    => _unitOfWork ??= new UnitOfWork();

    public async Task<List<MedicationCategoryQuanTn>> GetAllAsync()
    {
        return await _unitOfWork.MedicationCategoryQuanTnRepository.GetAllAsync();
    }

    public async Task<int> CreateAsync(MedicationCategoryQuanTn medicationCategoryQuanTn)
    {
        var result = await _unitOfWork.MedicationCategoryQuanTnRepository.CreateMedicationCategoryAsync(medicationCategoryQuanTn);
        return result;
    }
}
