using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message> {
	public void Configure(EntityTypeBuilder<Message> builder) {
		builder.HasKey(t => t.Id);
		builder.Property(t => t.Content).IsRequired();
		builder.Property(t => t.SenderId).IsRequired();
		builder.Property(t => t.ReceiverId).IsRequired();
		builder.Property(t => t.SentAt).IsRequired();
	}
}
