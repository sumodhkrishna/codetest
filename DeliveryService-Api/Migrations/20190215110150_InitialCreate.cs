using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryEntities",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseCost = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    WeekendDelivery = table.Column<bool>(nullable: false),
                    GoldRated = table.Column<bool>(nullable: false),
                    HasCoupen = table.Column<bool>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    NewCustomer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryEntities", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryEntities");
        }
    }
}
