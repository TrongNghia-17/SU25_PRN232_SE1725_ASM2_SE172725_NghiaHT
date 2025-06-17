namespace SMMS.Services.NghiaHT;

public interface IServiceProviders
{
    SystemUserAccountService UserAccountService { get; }
    IRequestNghiaHtService RequestNghiaHtService { get; }
    MedicationCategoryQuanTnService MedicationCategoryQuanTnService { get; }
}
public class ServiceProviders : IServiceProviders
{
    private SystemUserAccountService _systemUserAccountService;
    private IRequestNghiaHtService _requestNghiaHtService;
    private MedicationCategoryQuanTnService _medicationCategoryQuanTnService;

    public ServiceProviders() { }

    public SystemUserAccountService UserAccountService
    {
        get { return _systemUserAccountService ??= new SystemUserAccountService(); }
    }
    public IRequestNghiaHtService RequestNghiaHtService
    {
        get { return _requestNghiaHtService ??= new RequestNghiaHtService(); }
    }
    public MedicationCategoryQuanTnService MedicationCategoryQuanTnService
    {
        get { return _medicationCategoryQuanTnService ??= new MedicationCategoryQuanTnService(); }
    }
}
