namespace AccSol.EF.Repositories
{
    public interface IRepositoryManager
    {
        ICoaRepository Coa { get; }
        IClientRepository Client { get; }
        IEmployeeRepository Employee { get; }
        IProjectCodeRepository ProjectCode { get; }
        IPettyCashRepository PettyCash { get; }
        void Save();
    }
}
