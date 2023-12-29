using AccSol.EF.Models;

namespace AccSol.EF.Services
{
    public interface ICommonService<T>
    {
        Task<IEnumerable<T>?> GetAll();
        Task<T?> Get(int id);
        Task<T?> Create(T? model);
        Task<T?> Update(T? model);
        Task Delete(int id);
    }
}
