using TimeJournal.DataModel.Entities;

namespace TimeJournal.Repositories;

public interface IActivityRepository
{
    IQueryable<Activity> Query();
    Task<IEnumerable<Activity>> GetAll();
    Task<Activity> Get(int id);
    Task Add(Activity activity);
    Task EnsureActivity(int id);
}