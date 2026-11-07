namespace TwitterClone.Domain.Entities;

public class Message : BaseEntity {
	public Message() : this(string.Empty, Guid.Empty, Guid.Empty) {}

	public Message(string content, Guid senderId, Guid recieverId) :
	    base(Guid.NewGuid()) {
		Content    = content;
		SenderId   = senderId;
		RecieverId = recieverId;
		SentAt     = CreatedAt;
	}

	public Guid     SenderId { get; set; }
	public Guid     RecieverId { get; set; }
	public DateTime SentAt { get; set; }

	public string Content { set; get; }
	public bool   IsRead { set; get; }

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nMessage: SenderId: {SenderId}, RecieverId: {RecieverId}, Content: {Content}, SentAt: {SentAt}, IsRead: {IsRead}";
	}
}
