using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace snow_bc_api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provience",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provience_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Production",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProvienceId = table.Column<Guid>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Provience_ProvienceId",
                        column: x => x.ProvienceId,
                        principalSchema: "Production",
                        principalTable: "Provience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityMonth",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    MonthId = table.Column<Guid>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityMonth_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Production",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityMonth_Month_MonthId",
                        column: x => x.MonthId,
                        principalSchema: "Production",
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTopic",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    TopicId = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTopic_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Production",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Production",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    IsMainImage = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Production",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Production",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodAndDrink",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodAndDrink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodAndDrink_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sight",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sight_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvienceId",
                schema: "Production",
                table: "City",
                column: "ProvienceId");

            migrationBuilder.CreateIndex(
                name: "IX_CityMonth_CityId",
                schema: "Production",
                table: "CityMonth",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityMonth_MonthId",
                schema: "Production",
                table: "CityMonth",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTopic_CityId",
                schema: "Production",
                table: "CityTopic",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTopic_TopicId",
                schema: "Production",
                table: "CityTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAndDrink_LocationId",
                schema: "Production",
                table: "FoodAndDrink",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CityId",
                schema: "Production",
                table: "Image",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CityId",
                schema: "Production",
                table: "Location",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Provience_CountryId",
                schema: "Production",
                table: "Provience",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sight_LocationId",
                schema: "Production",
                table: "Sight",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityMonth",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "CityTopic",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "FoodAndDrink",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Sight",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Month",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Topic",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Provience",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Production");
        }
    }
}
