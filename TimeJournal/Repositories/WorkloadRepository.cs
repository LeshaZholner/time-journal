using Microsoft.EntityFrameworkCore;
using TimeJournal.DataModel.Entities;
using TimeJournal.DbContexts;
using TimeJournal.Repositories.Exceptions;

namespace TimeJournal.Repositories;

public class WorkloadRepository : IWorkloadRepository
{
    private readonly TimeJournalDbContext _context;

    public WorkloadRepository(TimeJournalDbContext context)
    {
        _context = context;
    }

    public IQueryable<Workload> Query() => _context.Workload;

    public async Task<IEnumerable<Workload>> GetAll()
    {
        return await _context.Workload.ToListAsync();
    }

    public async Task<Workload> Get(int id)
    {
        return await _context.Workload.FirstOrDefaultAsync()
               ?? throw new ObjectNotFoundException($"Workload '{id}' not found");
    }

    public async Task Add(Workload workload)
    {
        _context.Workload.Add(workload);
        await _context.SaveChangesAsync();
    }
}