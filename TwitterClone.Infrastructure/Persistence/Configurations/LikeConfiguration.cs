using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like> {
	public void Configure(EntityTypeBuilder<Like> builder) {
		builder.HasKey(t => t.Id);
		builder.Property(t => t.UserId).IsRequired();
		builder.Property(t => t.TweetId).IsRequired();
	}
}
