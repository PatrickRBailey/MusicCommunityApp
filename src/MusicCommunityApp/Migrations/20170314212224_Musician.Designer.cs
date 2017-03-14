using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MusicCommunityApp.Repositories;

namespace MusicCommunityApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170314212224_Musician")]
    partial class Musician
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicCommunityApp.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<int?>("MessageID");

                    b.HasKey("CommentID");

                    b.HasIndex("MessageID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("MusicCommunityApp.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("MusicCommunityApp.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<string>("EventName")
                        .IsRequired();

                    b.Property<int?>("FromMusicianID");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("MessageID");

                    b.HasIndex("FromMusicianID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MusicCommunityApp.Models.Musician", b =>
                {
                    b.Property<int>("MusicianID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Id");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("MusicianID");

                    b.ToTable("Musician");
                });

            modelBuilder.Entity("MusicCommunityApp.Models.Comment", b =>
                {
                    b.HasOne("MusicCommunityApp.Models.Message")
                        .WithMany("Comments")
                        .HasForeignKey("MessageID");
                });

            modelBuilder.Entity("MusicCommunityApp.Models.Message", b =>
                {
                    b.HasOne("MusicCommunityApp.Models.Musician", "From")
                        .WithMany()
                        .HasForeignKey("FromMusicianID");
                });
        }
    }
}
