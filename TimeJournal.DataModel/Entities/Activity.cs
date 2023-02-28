using TimeJournal.DataModel.Common;

namespace TimeJournal.DataModel.Entities;

public class Activity : AuditedEntity
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual Project? Project { get; set; }
    public virtual ICollection<Workload> Workloads { get; set; } = new List<Workload>();
}
