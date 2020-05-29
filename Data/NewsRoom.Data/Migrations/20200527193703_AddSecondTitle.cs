namespace NewsRoom.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddSecondTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondTitle",
                table: "News",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondTitle",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
