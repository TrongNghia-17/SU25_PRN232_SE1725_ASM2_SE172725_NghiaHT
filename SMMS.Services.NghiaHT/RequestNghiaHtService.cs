using SMMS.Repositories.NghiaHT;
using SMMS.Repositories.NghiaHT.ModelExtensions;
using SMMS.Repositories.NghiaHT.Models;

namespace SMMS.Services.NghiaHT;

//public interface IRequestNghiaHtService
//{

//}

public class RequestNghiaHtService : IRequestNghiaHtService
{
    //private readonly RequestNghiaHtRepository _requestNghiaHtRepository;
    private IUnitOfWork _unitOfWork;

    public RequestNghiaHtService()
    => _unitOfWork ??= new UnitOfWork();

    public async Task<int> CreateAsync(RequestNghiaHt requestNghiaHt)
    {
        return await _unitOfWork.RequestNghiaHtRepository.CreateAsync(requestNghiaHt);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _unitOfWork.RequestNghiaHtRepository.GetByIdAsync(id);
        return await _unitOfWork.RequestNghiaHtRepository.RemoveAsync(item);
    }

    public async Task<List<RequestNghiaHt>> GetAllAsync()
    {
        return await _unitOfWork.RequestNghiaHtRepository.GetAllAsync();
    }

    public async Task<RequestNghiaHt> GetByIdAsync(int id)
    {
        return await _unitOfWork.RequestNghiaHtRepository.GetByIdAsync(id);
    }

    public async Task<List<RequestNghiaHt>> SearchAllAsync(string medicationName, int quantity, string categoryName)
    {
        return await _unitOfWork.RequestNghiaHtRepository.SearchAsync(medicationName, quantity, categoryName);
    }

    public async Task<int> UpdateAsync(RequestNghiaHt requestNghiaHt)
    {
        return await _unitOfWork.RequestNghiaHtRepository.UpdateAsync(requestNghiaHt);
    }

    public Task<PaginationResult<List<RequestNghiaHt>>> SearchWithPagingAsync(string medicationName, int quantity, string categoryName, int currentPage, int pageSize)
    {
        return _unitOfWork.RequestNghiaHtRepository.SearchAsync(medicationName, quantity, categoryName, currentPage, pageSize);
    }

    public Task<PaginationResult<List<RequestNghiaHt>>> GetAllWithPaging(int currentPage, int pageSize)
    {
        return _unitOfWork.RequestNghiaHtRepository.GetAllWithPaging(currentPage, pageSize);
    }

    public async Task<PaginationResult<List<RequestNghiaHt>>> SearchWithPagingAsync(SearchRequestNghiaHt searchRequest)
    {
        var list = await _unitOfWork.RequestNghiaHtRepository.SearchWithPaginAsync(searchRequest);
        return list ?? new PaginationResult<List<RequestNghiaHt>>();
    }
}
