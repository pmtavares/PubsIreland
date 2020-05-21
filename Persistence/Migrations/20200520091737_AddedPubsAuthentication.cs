using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedPubsAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Pubs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Pubs",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Pubs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Pubs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Pubs");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Pubs");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Pubs");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Pubs");
        }
    }
}
