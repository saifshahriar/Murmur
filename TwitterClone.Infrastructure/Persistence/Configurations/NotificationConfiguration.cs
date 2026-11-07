using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations;

public class NotificationConfiguration :
    IEntityTypeConfiguration<Notification> {
	public void Configure(EntityTypeBuilder<Notification> builder) {
		builder.HasKey(t => t.Id);
		builder.ToTable("Notifications");

		builder.Property(t => t.UserId).IsRequired();
		builder.Property(t => t.Type).IsRequired();
		builder.Property(t => t.Content).IsRequired();

		// The notification kinds are stored in one table, discriminated by
		// the Type column (Table Per Hierarchy).
		builder.HasDiscriminator<NotificationType>("Type");

		builder.HasIndex(t => t.UserId);
	}
}
