using ContactManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Data.Configurations
{
    public class CsvConfiguration : IEntityTypeConfiguration<CsvModel>
    {
        public void Configure(EntityTypeBuilder<CsvModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Phone)
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.Married)
                .IsRequired();

            builder.Property(x => x.Salary)
                .IsRequired();
        }
    }
}
