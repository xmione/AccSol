using AccSol.EF.Data;

namespace AccSol.EF.Repositories
{
    public class RepositoryManager:IRepositoryManager
    {
        private ApplicationDbContext _dbContext;
        private ICoaRepository? _coaRepository;
        private IClientRepository? _clientRepository;
        private IEmployeeRepository? _employeeRepository;
        private IProjectCodeRepository? _projectCodeRepository;
        private IPettyCashRepository? _pettyCashRepository;
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
         
        public IClientRepository Client
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new ClientRepository(_dbContext);
                return _clientRepository;
            }
        }
         
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_dbContext);
                return _employeeRepository;
            }
        }
         
        public IProjectCodeRepository ProjectCode
        {
            get
            {
                if (_projectCodeRepository == null)
                    _projectCodeRepository = new ProjectCodeRepository(_dbContext);
                return _projectCodeRepository;
            }
        }
         
        public IPettyCashRepository PettyCash
        {
            get
            {
                if (_pettyCashRepository == null)
                    _pettyCashRepository = new PettyCashRepository(_dbContext);
                return _pettyCashRepository;
            }
        }
         
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
