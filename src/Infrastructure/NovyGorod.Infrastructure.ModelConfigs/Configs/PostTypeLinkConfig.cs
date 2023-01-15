using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostTypeLinkConfig : IEntityTypeConfiguration<PostTypeLink>
{
    public void Configure(EntityTypeBuilder<PostTypeLink> builder)
    {
        builder.HasOne(x => x.Post).WithMany(x => x.TypeLinks).HasForeignKey(x => x.PostId);
        builder.HasKey(x => new {x.Type, x.PostId}).IsClustered();
    }
}