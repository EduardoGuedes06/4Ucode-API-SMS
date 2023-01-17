using _4Ucode_sms.Bussines.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FileUploadMappingMapping : IEntityTypeConfiguration<UploadDocument>
    {
        public void Configure(EntityTypeBuilder<UploadDocument> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FileName)
                .IsRequired()
                .HasColumnType("varchar(350)");


            builder.Property(p => p.ContentType)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Dados)
                .IsRequired()
                .HasColumnType("varchar(50)");


            builder.ToTable("Document");
        }
    }
}