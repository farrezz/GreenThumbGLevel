using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbGLevel.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantName", "PlantDescription", "PlantOrigin" },
                values: new object[,]
                {
                    { "Fiolfikus", "Trendig växt med fiolformade, glänsande, stora blad. En populär och lättskött planta som trivs i ljusa förhållanden, undvik direkt solljus.", "Danmark" },
                    { "Guldpalm", "Frodig, lättskött och populär palm med vackra blad som ger inredningen en tropisk touch.", "Danmark" },
                    { "Monstera", "Mycket lättskött och populär planta med stora, blanka, gröna blad och långa luftrötter.", "Nederländerna" },
                    { "Vit Papegojblomma", "Stor och vacker planta med stora gröna blad som växer i solfjäderform.", "Danmark" }
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Description", "PlantName" },
                values: new object[,]
                {
                    { 1, "undvik direkt solljus", "Fiolfikus" },
                    { 2, "Låt den torka lätt mellan vattningarna för att undvika rotröta.", "Fiolfikus" },
                    { 3, "Duscha den gärna regelbundet på bladen för att bibehålla hög luftfuktighet", "Fiolfikus" },
                    { 4, "Guldpalmen trivs i omgivningar utan direkt solljus.", "Guldpalm" },
                    { 5, "Under vinterhalvåret behöver den mindre näring.", "Guldpalm" },
                    { 6, "Sätt gärna ut på den på balkongen eller terrassen om sommaren i skuggan.", "Guldpalm" },
                    { 7, "Papegojblomma trivs i miljöer med god tillgång till ljus", "Vit Papegojblomma" },
                    { 8, "Undvik direkt solljus som kan bränna bladen.", "Vit Papegojblomma" },
                    { 9, "Låt den torka lätt mellan vattningarna, men duscha den gärna ofta på bladen för att bibehålla hög luftfuktighet. ", "Vit Papegojblomma" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantName",
                keyValue: "Monstera");

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantName",
                keyValue: "Fiolfikus");

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantName",
                keyValue: "Guldpalm");

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantName",
                keyValue: "Vit Papegojblomma");
        }
    }
}
