using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicCommunityApp.Migrations
{
    public partial class EventName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Event",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "Messages",
                nullable: true);
        }
    }
}
