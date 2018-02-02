using ListenThen.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListenThen.Infra.Data.Mappings
{
    public class OneToOneMeetingMap : IEntityTypeConfiguration<OneToOneMeeeting>
    {
        public void Configure(EntityTypeBuilder<OneToOneMeeeting> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.HasOne(p => p.Manager)
                .WithMany(p => p.OneToOneMeetingManagers);

            builder.HasOne(p => p.Receiver)
                .WithMany(p => p.OneToOneMeetingReceivers);

            builder.HasMany(p => p.Points)
                .WithOne(p => p.OneToOneMeeting);

            builder.HasMany(p => p.Notes)
                .WithOne(p => p.OneToOneMeeting);

            builder.Property(p => p.Created)
                .HasColumnName("Created");
        }
    }
}