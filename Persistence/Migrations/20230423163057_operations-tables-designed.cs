using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class operationstablesdesigned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_users_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims");

            migrationBuilder.RenameTable(
                name: "UserOperationClaims",
                newName: "user_operation_claims");

            migrationBuilder.RenameTable(
                name: "OperationClaims",
                newName: "operation_claims");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_operation_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_operation_claims",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "OperationClaimId",
                table: "user_operation_claims",
                newName: "operation_claim_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "user_operation_claims",
                newName: "IX_user_operation_claims_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "user_operation_claims",
                newName: "IX_user_operation_claims_operation_claim_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "operation_claims",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "operation_claims",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_operation_claims",
                table: "user_operation_claims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operation_claims",
                table: "operation_claims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_operation_claims_operation_claims_operation_claim_id",
                table: "user_operation_claims",
                column: "operation_claim_id",
                principalTable: "operation_claims",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_operation_claims_users_user_id",
                table: "user_operation_claims",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_operation_claims_operation_claims_operation_claim_id",
                table: "user_operation_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_operation_claims_users_user_id",
                table: "user_operation_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_operation_claims",
                table: "user_operation_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operation_claims",
                table: "operation_claims");

            migrationBuilder.RenameTable(
                name: "user_operation_claims",
                newName: "UserOperationClaims");

            migrationBuilder.RenameTable(
                name: "operation_claims",
                newName: "OperationClaims");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserOperationClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserOperationClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "operation_claim_id",
                table: "UserOperationClaims",
                newName: "OperationClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_user_operation_claims_user_id",
                table: "UserOperationClaims",
                newName: "IX_UserOperationClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_operation_claims_operation_claim_id",
                table: "UserOperationClaims",
                newName: "IX_UserOperationClaims_OperationClaimId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "OperationClaims",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OperationClaims",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_users_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
