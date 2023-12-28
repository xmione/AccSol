using AccSol.EF.Data;

namespace AccSol.EF.Repositories
{
    public class RepositoryManager:IRepositoryManager
    {
        private ApplicationDbContext _dbContext;
        private ICoaRepository? _coaRepository;
        public RepositoryManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICoaRepository Coa
        {
            get
            {
                if (_coaRepository == null)
                    _coaRepository = new CoaRepository(_dbContext);
                return _coaRepository;
            }
        }
         
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
