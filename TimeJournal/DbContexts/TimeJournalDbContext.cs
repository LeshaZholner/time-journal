using Microsoft.EntityFrameworkCore;
using TimeJournal.DataModel.Entities;

namespace TimeJournal.DbContexts;

public class TimeJournalDbContext : DbContext
{
    public DbSet<Project> Project => Set<Project>();
	public DbSet<Activity> Activity => Set<Activity>();
	public DbSet<Workload> Workload => Set<Workload>();

	public TimeJournalDbContext(DbContextOptions<TimeJournalDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Project>()
			.HasKey(p => p.Id);
		modelBuilder.Entity<Project>()
			.Property(p => p.Id)
			.UseIdentityColumn(seed: 10000);

        modelBuilder.Entity<Activity>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Activity>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 10000);
    }
}
