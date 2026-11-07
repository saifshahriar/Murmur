using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations;

public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark> {
	public void Configure(EntityTypeBuilder<Bookmark> builder) {
		builder.HasKey(t => t.Id);
		builder.Property(t => t.TweetId).IsRequired();
		builder.Property(t => t.UserId).IsRequired();
	}
}
