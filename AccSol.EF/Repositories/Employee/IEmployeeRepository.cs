using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll(bool trackChanges);
        Employee? Get(int? id, bool trackChanges);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
