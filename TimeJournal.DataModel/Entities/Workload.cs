using TimeJournal.DataModel.Common;

namespace TimeJournal.DataModel.Entities;

public class Workload : AuditedEntity
{
    public int Id { get; set; }
    public int ActivityId { get; set; }
    public double Duration { get; set; }
    public DateTime Date { get; set; }
    public virtual Activity? Activity { get; set; }
}
