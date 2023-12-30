using AccSol.EF.Data;
using AccSol.EF.Models;

namespace AccSol.EF.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Employee> GetAll(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();
        public Employee? Get(int? id, bool trackChanges) =>
        FindByCondition(c => c.ID == id, trackChanges)
        .FirstOrDefault();

        public void CreateEmployee(Employee coa) => Create(coa);
        public void UpdateEmployee(Employee coa) => Update(coa);
        public void DeleteEmployee(Employee coa) => Delete(coa);
    }
}