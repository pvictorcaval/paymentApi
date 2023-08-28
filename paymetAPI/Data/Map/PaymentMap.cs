using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paymetAPI.Models;

namespace paymetAPI.Data.Map
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.description).HasMaxLength(150);
            builder.Property(x => x.paymentDate).IsRequired();
            builder.Property(x => x.paymentValue).IsRequired();
        }
    }
}
