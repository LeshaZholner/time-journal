using TimeJournal.DataModel.Entities;

namespace TimeJournal.Repositories;

public interface IProjectRepository
{
    IQueryable<Project> Query();
    Task<IEnumerable<Project>> GetAll();
    Task<Project> Get(int projectId);
    Task Add(Project project);
    Task EnsureProject(int id);
}
