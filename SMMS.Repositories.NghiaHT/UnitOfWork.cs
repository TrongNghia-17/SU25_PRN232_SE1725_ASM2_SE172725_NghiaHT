using SMMS.Repositories.NghiaHT.DBContext;

namespace SMMS.Repositories.NghiaHT;

public interface IUnitOfWork : IDisposable
{
    SystemUserAccountRepository SystemUserAccountRepository { get; }
    RequestNghiaHtRepository RequestNghiaHtRepository { get; }
    MedicationCategoryQuanTnRepository MedicationCategoryQuanTnRepository { get; }

    int SaveChangesWithTransaction();
    Task<int> SaveChangesWithTransactionAsync();
}
public class UnitOfWork : IUnitOfWork
{
    private readonly SU25_PRN232_SE1725_G2_SMMSContext _context;
    private SystemUserAccountRepository _systemUserAccountRepository;
    private RequestNghiaHtRepository _requestNghiaHtRepository;
    private MedicationCategoryQuanTnRepository _medicationCategoryQuanTnRepository;


    public UnitOfWork() => _context ??= new SU25_PRN232_SE1725_G2_SMMSContext();

    public SystemUserAccountRepository SystemUserAccountRepository
    {
        get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
    }
    public RequestNghiaHtRepository RequestNghiaHtRepository
    {
        get { return _requestNghiaHtRepository ??= new RequestNghiaHtRepository(_context); }
    }

    public MedicationCategoryQuanTnRepository MedicationCategoryQuanTnRepository
    {
        get { return _medicationCategoryQuanTnRepository ??= new MedicationCategoryQuanTnRepository(_context); }
    }


    public void Dispose() => _context.Dispose();

    public int SaveChangesWithTransaction()
    {
        int result = -1;

        //System.Data.IsolationLevel.Snapshot
        using (var dbContextTransaction = _context.Database.BeginTransaction())
        {
            try
            {
                result = _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception)
            {
                //Log Exception Handling message                      
                result = -1;
                dbContextTransaction.Rollback();
            }
        }

        return result;
    }

    public async Task<int> SaveChangesWithTransactionAsync()
    {
        int result = -1;

        //System.Data.IsolationLevel.Snapshot
        using (var dbContextTransaction = _context.Database.BeginTransaction())
        {
            try
            {
                result = await _context.SaveChangesAsync();
                dbContextTransaction.Commit();
            }
            catch (Exception)
            {
                //Log Exception Handling message                      
                result = -1;
                dbContextTransaction.Rollback();
            }
        }

        return result;
    }
}
