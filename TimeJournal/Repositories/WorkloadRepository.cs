using Microsoft.EntityFrameworkCore;
using TimeJournal.DataModel.Entities;
using TimeJournal.DbContexts;
using TimeJournal.Repositories.Exceptions;

namespace TimeJournal.Repositories;

public class WorkloadRepository : IWorkloadRepository
{
    private readonly TimeJournalDbContext _context;
    private readonly IActivityRepository _activityRepository;

    public WorkloadRepository(TimeJournalDbContext context,
        IActivityRepository activityRepository)
    {
        _context = context;
        _activityRepository = activityRepository;
    }

    public IQueryable<Workload> Query() => _context.Workload;

    public async Task<IEnumerable<Workload>> GetAll()
    {
        return await _context.Workload.ToListAsync();
    }

    public async Task<Workload> Get(int id)
    {
        return await _context.Workload.FirstOrDefaultAsync()
               ?? throw WorkloadNotFoundException(id);
    }

    public async Task Add(Workload workload)
    {
        await _activityRepository.EnsureActivity(workload.ActivityId);
        _context.Workload.Add(workload);
        await _context.SaveChangesAsync();
    }

    public async Task EnsureWorkload(int id)
    {
        var workload = await _context.Workload.FirstOrDefaultAsync();
        if (workload is null)
        {
            throw WorkloadNotFoundException(id);
        }
    }

    private static ObjectNotFoundException WorkloadNotFoundException(int id)
    {
        return new ObjectNotFoundException($"Workload '{id}' not found");
    }
}