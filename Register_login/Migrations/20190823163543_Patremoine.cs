using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Register_login.Migrations
{
    public partial class Patremoine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patremoines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    designation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    adresse = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    superficie = table.Column<string>(nullable: true),
                    couvert = table.Column<string>(nullable: true),
                    num1 = table.Column<string>(nullable: true),
                    observation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    nature = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    pv_affectaion = table.Column<string>(nullable: true),
                    cf = table.Column<string>(nullable: true),
                    cv = table.Column<string>(nullable: true),
                    cl = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    nompropritaire = table.Column<string>(nullable: true),
                    montant = table.Column<string>(nullable: true),
                    id_direction = table.Column<int>(nullable: false),
                    id_region = table.Column<int>(nullable: false),
                    id_delegation = table.Column<int>(nullable: false),
                    id_arrandissement = table.Column<int>(nullable: false),
                    id_typePatremoine = table.Column<int>(nullable: false),
                    datecreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patremoines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patremoines");
        }
    }
}
