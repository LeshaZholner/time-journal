using Microsoft.EntityFrameworkCore;
using TimeJournal.DataModel.Entities;
using TimeJournal.DbContexts;
using TimeJournal.Repositories.Exceptions;

namespace TimeJournal.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly TimeJournalDbContext _context;

    public ActivityRepository(TimeJournalDbContext context)
    {
        _context = context;
    }

    public IQueryable<Activity> Query() => _context.Activity;
    
    public async Task<IEnumerable<Activity>> GetAll()
    {
        return await _context.Activity.ToListAsync();
    }

    public async Task<Activity> Get(int id)
    {
        return await _context.Activity.FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new ObjectNotFoundException($"Activity '{id}' not found.");
    }

    public async Task Add(Activity activity)
    {
        _context.Activity.Add(activity);
        await _context.SaveChangesAsync();
    }
}