using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class createAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Accounts");

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmEmail",
                table: "Accounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConfirmEmail",
                value: false);

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4401));

            migrationBuilder.UpdateData(
                table: "GenrePlaylists",
                keyColumns: new[] { "GenreId", "PlaylistId" },
                keyValues: new object[] { 1, 2 },
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "GenrePlaylists",
                keyColumns: new[] { "GenreId", "PlaylistId" },
                keyValues: new object[] { 2, 2 },
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4206), new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4259), new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4262) });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 47, 41, 761, DateTimeKind.Utc).AddTicks(4472));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmEmail",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Accounts",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConfirmPassword",
                value: "Qwerty-1");

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.UpdateData(
                table: "GenrePlaylists",
                keyColumns: new[] { "GenreId", "PlaylistId" },
                keyValues: new object[] { 1, 2 },
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "GenrePlaylists",
                keyColumns: new[] { "GenreId", "PlaylistId" },
                keyValues: new object[] { 2, 2 },
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(796), new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(839) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(844), new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 2, 13, 45, 21, 123, DateTimeKind.Utc).AddTicks(1088));
        }
    }
}
