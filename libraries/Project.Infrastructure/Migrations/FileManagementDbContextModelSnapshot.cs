// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Migrations
{
    [DbContext(typeof(FileManagementDbContext))]
    partial class FileManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Core.Domain.Demo.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProfileImageId")
                        .HasColumnType("bigint");

                    b.Property<long>("SateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProfileImageId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Project.Core.Domain.Media.MediaFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("MediaFolderId")
                        .HasColumnType("bigint");

                    b.Property<int>("MediaType")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MediaFolderId");

                    b.ToTable("MediaFile");
                });

            modelBuilder.Entity("Project.Core.Domain.Media.MediaFolder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FolderUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MediaFolder");
                });

            modelBuilder.Entity("Project.Core.Domain.Demo.Employee", b =>
                {
                    b.HasOne("Project.Core.Domain.Media.MediaFile", "MediaFile")
                        .WithMany("Employees")
                        .HasForeignKey("ProfileImageId");

                    b.Navigation("MediaFile");
                });

            modelBuilder.Entity("Project.Core.Domain.Media.MediaFile", b =>
                {
                    b.HasOne("Project.Core.Domain.Media.MediaFolder", "MediaFolder")
                        .WithMany("MediaFiles")
                        .HasForeignKey("MediaFolderId")
                        .IsRequired();

                    b.Navigation("MediaFolder");
                });

            modelBuilder.Entity("Project.Core.Domain.Media.MediaFile", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Project.Core.Domain.Media.MediaFolder", b =>
                {
                    b.Navigation("MediaFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
