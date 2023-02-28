﻿using Microsoft.EntityFrameworkCore;
using TimeJournal.DataModel.Entities;
using TimeJournal.DbContexts;
using TimeJournal.Repositories.Exceptions;

namespace TimeJournal.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TimeJournalDbContext _context;

    public ProjectRepository(TimeJournalDbContext context)
    {
        _context = context;
    }

    public IQueryable<Project> Query() => _context.Project;

    public async Task Add(Project project)
    {
        _context.Project.Add(project);
        await _context.SaveChangesAsync();
    }

    public async Task<Project> Get(int projectId)
    {
        return await _context.Project.FirstOrDefaultAsync(x => x.Id == projectId)
            ?? throw new ObjectNotFoundException($"Project '{projectId}' not found.");
    }
}