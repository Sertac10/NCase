﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AirDate",
                table: "Episodes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApiCreatedDate",
                table: "Episodes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeApiId",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EpisodeStamp",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiCreatedDate",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "EpisodeApiId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "EpisodeStamp",
                table: "Episodes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AirDate",
                table: "Episodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
