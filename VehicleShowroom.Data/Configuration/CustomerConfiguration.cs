using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Customer;
namespace VehicleShowroom.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.CustomerId);

            builder
                .HasOne(c => c.User)
                .WithMany() 
                .HasForeignKey(c => c.UserId)
            .IsRequired();

            builder
            .HasOne(c => c.Vehicle)
            .WithMany()
            .HasForeignKey(c => c.VehicleId)
            .IsRequired();

            builder
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameMaxLenght);
            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(LastNameMaxLenght);
            builder
               .Property(c => c.PhoneNumber)
               .IsRequired()
               .HasMaxLength(PhoneNumberMaxLenght);
        }
    }
}
