using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFieldsEnitities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_ArtistId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums");

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "character varying(160)",
                maxLength: 160,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "character varying(160)",
                maxLength: 160,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "character varying(240)",
                maxLength: 240,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PublisherId",
                table: "AspNetUsers",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Publishers_PublisherId",
                table: "AspNetUsers",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Publishers_PublisherId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PublisherId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Tracks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(160)",
                oldMaxLength: 160);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(160)",
                oldMaxLength: 160);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublisherId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    Image = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Nickname = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "user", "USER" },
                    { 2, null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Image", "IsBloked", "IsDeleted", "IsVerified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "6c10ce42-b824-4553-8028-92024794759d", "email@gmail.com", false, "Matt", "/TrackStorage/somee", false, false, false, "Daymon", false, null, null, null, null, null, false, null, false, "email@gmail.com" },
                    { 2, 0, "3b102cc1-d096-40d0-b38b-fad49043d1c1", "bayden@gmail.com", false, "Smit", "/TrackStorage/somee", false, false, false, "Bayden", false, null, null, null, null, null, false, null, false, "bayden@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5590), null, "Popular music characterized by upbeat melodies and catchy hooks.", "https://example.com/genres/pop.jpg", false, "Pop" },
                    { 2, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5594), null, "Guitar-driven music that originated in the 1950s and has evolved into various subgenres.", "https://example.com/genres/rock.jpg", false, "Rock" },
                    { 3, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5597), null, "Music that originated in African American and Latino communities in the Bronx in the 1970s, characterized by rapping, beats, and samples.", "https://example.com/genres/hiphop.jpg", false, "Hip-Hop" },
                    { 4, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5599), null, "Music that relies heavily on electronic instruments and technology, and can range from ambient to dance-oriented.", "https://example.com/genres/electronic.jpg", false, "Electronic" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Duration", "GenreId", "Image", "IsDeleted", "IsExplicit", "IsPublic", "Title", "UserEntityId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5637), null, "This is Playlist1", 3600, null, "https://example.com/playlist1.jpg", false, false, false, "Playlist1", null, null },
                    { 2, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5640), null, "This is Playlist2", 7200, null, "https://example.com/playlist2.jpg", false, false, false, "Playlist2", null, null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5471), new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5515), "Global music corporation", "https://example.com/universalmusic.jpg", false, "Universal Music Group" },
                    { 2, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5520), new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5522), "American music company", "https://example.com/sonymusic.jpg", false, "Sony Music Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "Nickname", "PublisherId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5541), null, "Pablo Ruiz Picasso was a Spanish painter, sculptor, printmaker, ceramicist and theatre designer who spent most of his adult life in France.", "https://example.com/picasso.jpg", false, "Picasso", 1 },
                    { 2, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5544), null, "Vincent Willem van Gogh was a Dutch post-impressionist painter who is among the most famous and influential figures in the history of Western art.", "https://example.com/vangogh.jpg", false, "Van Gogh", 1 },
                    { 3, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5547), null, "Leonardo di ser Piero da Vinci was an Italian polymath whose areas of interest included invention, drawing, painting.", "https://example.com/davinci.jpg", false, "Da Vinci", 1 }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "DateCreated", "DateUpdated", "Description", "Duration", "GenreId", "Image", "IsDeleted", "IsExplicit", "IsPublic", "Title", "UserEntityId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5564), null, "This is the first album.", 60, 1, "https://example.com/album1.jpg", false, false, false, "Album 1", null, null },
                    { 2, 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5568), null, "This is the second album.", 60, 2, "https://example.com/album1.jpg", false, false, false, "Album 2", null, null },
                    { 3, 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5570), null, "This is the 3 album.", 60, 1, "https://example.com/album1.jpg", false, false, false, "Album 3", null, null }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumId", "ArtistId", "DateCreated", "DateUpdated", "Description", "Duration", "GenreId", "Image", "IsDeleted", "IsExplicit", "IsPublic", "Path", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5619), null, "Rock", 300, 1, "/ImageStorage/ffsdgvsfg.jpg", false, false, false, "/TrackStorage/name1.mp3", "Track 1", 1 },
                    { 2, 2, 2, new DateTime(2023, 7, 2, 12, 34, 44, 675, DateTimeKind.Utc).AddTicks(5623), null, "This is the second track by Artist2.", 240, 2, "https://example.com/track2.jpg", false, false, false, "/TrackStorage/Track2.mp3", "Track2", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ArtistId",
                table: "Tracks",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PublisherId",
                table: "Artists",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
