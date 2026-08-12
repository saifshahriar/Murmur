namespace TwitterClone.Domain.Entities;

public class BaseEntity(Guid id) {
	public Guid     Id { get; private set; }        = id;
	public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
	public DateTime? ModifiedAt { get; private set; }
	public Guid CreatedBy { get; private set; }
	public Guid? ModifiedBy { get; private set; }

	public virtual string DescribeRecord() {
		return $"BaseEntity: Id: {Id}, CreatedAt: {CreatedAt}, ModifiedAt: {ModifiedAt}, CreatedBy: {CreatedBy}, ModifiedBy: {ModifiedBy}";
	}
}
