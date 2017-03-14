using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicCommunityApp.Migrations
{
    public partial class Musician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Members_FromMemberID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromMemberID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromMemberID",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "Musician",
                columns: table => new
                {
                    MusicianID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician", x => x.MusicianID);
                });

            migrationBuilder.AddColumn<int>(
                name: "FromMusicianID",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromMusicianID",
                table: "Messages",
                column: "FromMusicianID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Musician_FromMusicianID",
                table: "Messages",
                column: "FromMusicianID",
                principalTable: "Musician",
                principalColumn: "MusicianID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Musician_FromMusicianID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromMusicianID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromMusicianID",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Musician");

            migrationBuilder.AddColumn<int>(
                name: "FromMemberID",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromMemberID",
                table: "Messages",
                column: "FromMemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Members_FromMemberID",
                table: "Messages",
                column: "FromMemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
