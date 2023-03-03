using Microsoft.EntityFrameworkCore;
using TimeJournal.DataModel.Entities;
using TimeJournal.DbContexts;
using TimeJournal.Repositories.Exceptions;

namespace TimeJournal.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly TimeJournalDbContext _context;
    private readonly IProjectRepository _projectRepository;

    public ActivityRepository(TimeJournalDbContext context,
        IProjectRepository projectRepository)
    {
        _context = context;
        _projectRepository = projectRepository;
    }

    public IQueryable<Activity> Query() => _context.Activity;
    
    public async Task<IEnumerable<Activity>> GetAll()
    {
        return await _context.Activity.ToListAsync();
    }

    public async Task<Activity> Get(int id)
    {
        return await _context.Activity.FirstOrDefaultAsync(x => x.Id == id)
               ?? throw ActivityNotFoundException(id);
    }

    public async Task Add(Activity activity)
    {
        await _projectRepository.EnsureProject(activity.ProjectId);

        _context.Activity.Add(activity);
        await _context.SaveChangesAsync();
    }

    public async Task EnsureActivity(int id)
    {
        var activity = await _context.Activity.FirstOrDefaultAsync(x => x.Id == id);
        if(activity is null)
        {
            throw ActivityNotFoundException(id);
        }
    }

    private static ObjectNotFoundException ActivityNotFoundException(int id)
    {
        return new ObjectNotFoundException($"Activity '{id}' not found.");
    }
}