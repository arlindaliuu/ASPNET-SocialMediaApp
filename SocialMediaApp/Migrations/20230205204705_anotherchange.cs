using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaApp.Migrations
{
    public partial class anotherchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Likes_likesID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_likesID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "likesID",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostsId",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostsId",
                table: "Likes",
                column: "PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostsId",
                table: "Likes",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostsId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_PostsId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "PostsId",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "likesID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_likesID",
                table: "Posts",
                column: "likesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Likes_likesID",
                table: "Posts",
                column: "likesID",
                principalTable: "Likes",
                principalColumn: "ID");
        }
    }
}
