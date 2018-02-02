using ListenThen.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListenThen.Infra.Data.Mappings
{
    public class MeetingPointMap : IEntityTypeConfiguration<MeetingPoint>
    {
        public void Configure(EntityTypeBuilder<MeetingPoint> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Description)
                .HasColumnName("Description");

            builder.HasOne(p => p.Author)
                .WithMany(p => p.MeetingPointAuthors);

            builder.Property(p => p.Created)
                .HasColumnName("Created");
        }
    }
}