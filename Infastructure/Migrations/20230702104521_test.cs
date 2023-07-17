using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "Image", "LastName", "Password" },
                values: new object[] { 1, "Qwerty-1", "Alextest@gmail.com", "Alex", "https://example.com/popplaylist.jpg", "Alex123", "Qwerty-1" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Alboms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "GenrePlaylists",
                keyColumns: new[] { "GenreId", "PlaylistId" },
                keyValues: new object[] { 1, 2 },
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "GenrePlaylists",
                keyColumns: new[] { "GenreId", "PlaylistId" },
                keyValues: new object[] { 2, 2 },
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8148), new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8194) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8199), new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8201) });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 18, 13, 54, 22, 680, DateTimeKind.Utc).AddTicks(8413));
        }
    }
}
