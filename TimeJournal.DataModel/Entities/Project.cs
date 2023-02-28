using TimeJournal.DataModel.Common;

namespace TimeJournal.DataModel.Entities;

public class Project : AuditedEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
