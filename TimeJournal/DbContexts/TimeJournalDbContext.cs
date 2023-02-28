using Microsoft.EntityFrameworkCore;
using TimeJournal.DataModel.Entities;

namespace TimeJournal.DbContexts;

public class TimeJournalDbContext : DbContext
{
    public DbSet<Project> Project => Set<Project>();

	public TimeJournalDbContext(DbContextOptions<TimeJournalDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Project>()
			.HasKey(p => p.Id);
		//modelBuilder.Entity<Project>()
		//	.Property(p => p.Id)
  //          .UseIdentityColumn(seed: 10000);
	}
}
