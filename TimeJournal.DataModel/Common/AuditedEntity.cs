namespace TimeJournal.DataModel.Common;

public abstract class AuditedEntity
{
    public DateTime CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
}
