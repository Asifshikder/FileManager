using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Domain.Demo;
using Project.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.ModelBuilders.Demo
    {
    public class MediaFileConfiguration : IEntityTypeConfiguration<MediaFile>
    {
        public void Configure(EntityTypeBuilder<MediaFile> builder)
        {
            builder.HasOne(p => p.MediaFolder)
             .WithMany(r => r.MediaFiles)
             .HasForeignKey(d => d.MediaFolderId)
             .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
