using ListenThen.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListenThen.Infra.Data.Mappings
{
    public class MeetingNoteMap : IEntityTypeConfiguration<MeetingNote>
    {
        public void Configure(EntityTypeBuilder<MeetingNote> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Description)
                .HasColumnName("Description");

            builder.HasOne(p => p.Author)
                .WithMany(p => p.MeetingNoteAuthors);

            builder.Property(p => p.Created)
                .HasColumnName("Created");
        }
    }
}