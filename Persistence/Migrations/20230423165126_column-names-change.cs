using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class columnnameschange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kids_users_ParentId",
                table: "kids");

            migrationBuilder.DropForeignKey(
                name: "FK_refresh_tokens_users_UserId",
                table: "refresh_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_story_messages_stories_StoryId",
                table: "story_messages");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "user_operation_claims",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "user_operation_claims",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "story_messages",
                newName: "story_id");

            migrationBuilder.RenameIndex(
                name: "IX_story_messages_StoryId",
                table: "story_messages",
                newName: "IX_story_messages_story_id");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "refresh_tokens",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "refresh_tokens",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "refresh_tokens",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "refresh_tokens",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_refresh_tokens_UserId",
                table: "refresh_tokens",
                newName: "IX_refresh_tokens_user_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "operation_claims",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "operation_claims",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "kids",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "kids",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_kids_ParentId",
                table: "kids",
                newName: "IX_kids_parent_id");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "kids",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_kids_UserId",
                table: "kids",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_kids_users_UserId",
                table: "kids",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_kids_users_parent_id",
                table: "kids",
                column: "parent_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_tokens_users_user_id",
                table: "refresh_tokens",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_story_messages_stories_story_id",
                table: "story_messages",
                column: "story_id",
                principalTable: "stories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kids_users_UserId",
                table: "kids");

            migrationBuilder.DropForeignKey(
                name: "FK_kids_users_parent_id",
                table: "kids");

            migrationBuilder.DropForeignKey(
                name: "FK_refresh_tokens_users_user_id",
                table: "refresh_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_story_messages_stories_story_id",
                table: "story_messages");

            migrationBuilder.DropIndex(
                name: "IX_kids_UserId",
                table: "kids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "kids");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "user_operation_claims",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "user_operation_claims",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "story_id",
                table: "story_messages",
                newName: "StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_story_messages_story_id",
                table: "story_messages",
                newName: "IX_story_messages_StoryId");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "refresh_tokens",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "refresh_tokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "refresh_tokens",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "refresh_tokens",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_refresh_tokens_user_id",
                table: "refresh_tokens",
                newName: "IX_refresh_tokens_UserId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "operation_claims",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "operation_claims",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "kids",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "kids",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_kids_parent_id",
                table: "kids",
                newName: "IX_kids_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_kids_users_ParentId",
                table: "kids",
                column: "ParentId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_tokens_users_UserId",
                table: "refresh_tokens",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_story_messages_stories_StoryId",
                table: "story_messages",
                column: "StoryId",
                principalTable: "stories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
