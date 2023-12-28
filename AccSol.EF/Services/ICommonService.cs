using AccSol.EF.Models;

namespace AccSol.EF.Services
{
    public interface ICommonService<T>
    {
        Task<IEnumerable<T>?> GetAll();
        Task<T?> GetById(int id);
        Task<T?> Save(T model);
        Task Delete(int id);
    }
}
