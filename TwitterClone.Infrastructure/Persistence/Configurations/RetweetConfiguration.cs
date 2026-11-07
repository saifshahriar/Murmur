using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations;

public class RetweetConfiguration : IEntityTypeConfiguration<Retweet> {
	public void Configure(EntityTypeBuilder<Retweet> builder) {
		builder.HasKey(t => t.Id);
		builder.Property(t => t.Content).IsRequired();
		builder.Property(t => t.UserId).IsRequired();
		builder.Property(t => t.TweetId).IsRequired();
	}
}
