using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations;

public class TweetConfiguration : IEntityTypeConfiguration<Tweet> {
	public void Configure(EntityTypeBuilder<Tweet> builder) {
		builder.HasKey(t => t.Id);

		builder.Property(t => t.UserId).IsRequired();
		builder.Property(t => t.Content).IsRequired();

		builder.HasOne(t => t.User)
		    .WithMany(u => u.Tweets)
		    .HasForeignKey(t => t.UserId)
		    .IsRequired();
	}
}
