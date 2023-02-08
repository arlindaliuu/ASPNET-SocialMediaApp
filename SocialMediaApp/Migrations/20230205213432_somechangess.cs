using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaApp.Migrations
{
    public partial class somechangess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LikesPosts",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    likesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikesPosts", x => new { x.PostsId, x.likesID });
                    table.ForeignKey(
                        name: "FK_LikesPosts_Likes_likesID",
                        column: x => x.likesID,
                        principalTable: "Likes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikesPosts_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikesPosts_likesID",
                table: "LikesPosts",
                column: "likesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikesPosts");

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
    }
}
