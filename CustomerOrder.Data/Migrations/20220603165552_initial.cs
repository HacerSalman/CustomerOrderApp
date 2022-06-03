using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerOrderApp.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "entity_status",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_status", x => x.v);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.v);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    barcode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    price = table.Column<double>(type: "double", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer_address",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    customer_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_address_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_address_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer_permission",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    permission = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_permission_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_permission_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_permission_permission_permission",
                        column: x => x.permission,
                        principalTable: "permission",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer_order",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_address_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    quantity = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_order_customer_address_customer_address_id",
                        column: x => x.customer_address_id,
                        principalTable: "customer_address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_order_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer_order_product",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_order_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    quantity = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    product_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<long>(type: "bigint", nullable: false),
                    Update_time = table.Column<long>(type: "bigint", nullable: false),
                    owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modifier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_order_product_customer_order_customer_order_id",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_order_product_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_order_product_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "entity_status",
                column: "v",
                values: new object[]
                {
                    "ACTIVE",
                    "PASSIVE",
                    "DELETED"
                });

            migrationBuilder.InsertData(
                table: "permission",
                column: "v",
                values: new object[]
                {
                    "CUSTOMER_MANAGE",
                    "CUSTOMER_ORDER_MANAGE",
                    "PRODUCT_MANAGE"
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_create_time",
                table: "customer",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_email",
                table: "customer",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_name",
                table: "customer",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_customer_status",
                table: "customer",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_customer_Update_time",
                table: "customer",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_create_time",
                table: "customer_address",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_customer_id",
                table: "customer_address",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_status",
                table: "customer_address",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_Update_time",
                table: "customer_address",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_create_time",
                table: "customer_order",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customer_address_id",
                table: "customer_order",
                column: "customer_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_status",
                table: "customer_order",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_Update_time",
                table: "customer_order",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_product_create_time",
                table: "customer_order_product",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_product_customer_order_id",
                table: "customer_order_product",
                column: "customer_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_product_product_id",
                table: "customer_order_product",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_product_status",
                table: "customer_order_product",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_product_Update_time",
                table: "customer_order_product",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_permission_create_time",
                table: "customer_permission",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_customer_permission_customer_id",
                table: "customer_permission",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_permission_permission_customer_id",
                table: "customer_permission",
                columns: new[] { "permission", "customer_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_permission_status",
                table: "customer_permission",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_customer_permission_Update_time",
                table: "customer_permission",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_product_create_time",
                table: "product",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_product_description",
                table: "product",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "IX_product_status",
                table: "product",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_product_Update_time",
                table: "product",
                column: "Update_time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_order_product");

            migrationBuilder.DropTable(
                name: "customer_permission");

            migrationBuilder.DropTable(
                name: "customer_order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "customer_address");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "entity_status");
        }
    }
}
