using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hotelReserv.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    nationality = table.Column<string>(nullable: true),
                    url_logo_image = table.Column<string>(nullable: true),
                    facebook = table.Column<string>(nullable: true),
                    ubication = table.Column<string>(nullable: true),
                    about = table.Column<string>(nullable: true),
                    oficialPage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reservs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entry = table.Column<DateTime>(nullable: false),
                    departure = table.Column<DateTime>(nullable: false),
                    hotelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservs_Hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "Hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservs_hotelId",
                table: "Reservs",
                column: "hotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservs");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
