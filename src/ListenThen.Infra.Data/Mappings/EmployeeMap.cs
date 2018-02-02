using ListenThen.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListenThen.Infra.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Name)
                .HasColumnName("Name");

            builder.Property(p => p.Surname)
                .HasColumnName("Surname");

            builder.Property(p => p.Email)
                .HasColumnName("Email");

            builder.Property(p => p.Genre)
                .HasColumnName("Genre");

            builder.HasOne(p => p.JobTitle)
                .WithMany(p => p.Employees);
        }
    }
}