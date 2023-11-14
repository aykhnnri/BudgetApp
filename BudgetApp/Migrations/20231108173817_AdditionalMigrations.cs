using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedSearches_BudgetCategories_CategoryId",
                table: "SavedSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BudgetCategories_CategoryId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBudgets_BudgetCategories_CategoryId",
                table: "UserBudgets");

            migrationBuilder.RenameColumn(
                name: "BudgetAmount",
                table: "UserBudgets",
                newName: "budget_amount");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "UserBudgets",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserBudgets_CategoryId",
                table: "UserBudgets",
                newName: "IX_UserBudgets_category_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transactions",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Transactions",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "transaction_id");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                newName: "IX_Transactions_category_id");

            migrationBuilder.RenameColumn(
                name: "Authenticator",
                table: "Settings",
                newName: "authenticator");

            migrationBuilder.RenameColumn(
                name: "LogoutTimer",
                table: "Settings",
                newName: "logout_timer");

            migrationBuilder.RenameColumn(
                name: "SearchParameters",
                table: "SavedSearches",
                newName: "search_parameters");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SavedSearches",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "SearchId",
                table: "SavedSearches",
                newName: "search_id");

            migrationBuilder.RenameIndex(
                name: "IX_SavedSearches_CategoryId",
                table: "SavedSearches",
                newName: "IX_SavedSearches_category_id");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "LinkedAccounts",
                newName: "account_type");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "LinkedAccounts",
                newName: "account_number");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "LinkedAccounts",
                newName: "account_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BudgetCategories",
                newName: "category_id");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserBudgets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "UserBudgets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedSearches_BudgetCategories_category_id",
                table: "SavedSearches",
                column: "category_id",
                principalTable: "BudgetCategories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BudgetCategories_category_id",
                table: "Transactions",
                column: "category_id",
                principalTable: "BudgetCategories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBudgets_BudgetCategories_category_id",
                table: "UserBudgets",
                column: "category_id",
                principalTable: "BudgetCategories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
