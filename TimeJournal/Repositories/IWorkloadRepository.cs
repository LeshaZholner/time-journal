using TimeJournal.DataModel.Entities;

namespace TimeJournal.Repositories;

public interface IWorkloadRepository
{
    IQueryable<Workload> Query();
    Task<IEnumerable<Workload>> GetAll();
    Task<Workload> Get(int id);
    Task Add(Workload workload);
}