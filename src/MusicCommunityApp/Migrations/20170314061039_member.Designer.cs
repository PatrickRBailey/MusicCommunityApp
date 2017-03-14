using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MusicCommunityApp.Repositories;

namespace MusicCommunityApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170314061039_member")]
    partial class member
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

                    b.Property<int?>("FromMemberID");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("MessageID");

                    b.HasIndex("FromMemberID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MusicCommunityApp.Models.Comment", b =>
                {
                    b.HasOne("MusicCommunityApp.Models.Message")
                        .WithMany("Comments")
                        .HasForeignKey("MessageID");
                });

            modelBuilder.Entity("MusicCommunityApp.Models.Message", b =>
                {
                    b.HasOne("MusicCommunityApp.Models.Member", "From")
                        .WithMany()
                        .HasForeignKey("FromMemberID");
                });
        }
    }
}
