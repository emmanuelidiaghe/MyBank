using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBank.Data.Migrations
{
    public partial class AddDateCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Login");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Login",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Login");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Login",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
