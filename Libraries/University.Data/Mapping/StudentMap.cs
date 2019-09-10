using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain;

namespace University.Data.Mapping
{
    public class StudentMap : UniversityEntityTypeConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);
            builder.Property(student => student.Name)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
