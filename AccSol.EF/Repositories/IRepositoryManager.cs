namespace AccSol.EF.Repositories
{
    public interface IRepositoryManager
    {
        ICoaRepository Coa { get; }
       
        void Save();
    }
}
