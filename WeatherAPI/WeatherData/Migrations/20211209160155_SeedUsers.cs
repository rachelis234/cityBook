using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherData.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
              migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Es','el0548461051@gmail.com')");
            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Toyby','toybybo@gmail.com')");
            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('rachel','rl4157291@gmail.com')");
            
       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
               .Sql("DELETE FROM Users");

           
        }
    }
}
