using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostConfig : EntityConfig<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasId()
            .ApplySequencedModelConfig();

        builder.HasMany(x => x.Blocks).WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId).IsRequired();

        // builder.HasMany(x => x.Tags)
        //     .WithMany(x => x.Posts)
        //     .UsingEntity<Dictionary<string, object>>("post_tag",
        //         right => right.HasOne<Tag>().WithMany().HasForeignKey("postId"),
        //         left => left.HasOne<Post>().WithMany().HasForeignKey("tagId"));
    }
}