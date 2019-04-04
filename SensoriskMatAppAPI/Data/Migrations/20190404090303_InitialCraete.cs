using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class InitialCraete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FreetextQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreetextQuestion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MultichoiceQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OneOption = table.Column<bool>(nullable: false),
                    OwnOption = table.Column<bool>(nullable: false),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultichoiceQuestion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Friendly = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FreetextAnswer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    FreetextQuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreetextAnswer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FreetextAnswer_FreetextQuestion_FreetextQuestionID",
                        column: x => x.FreetextQuestionID,
                        principalTable: "FreetextQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultichoiceQuestion_Options",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MultichoiceQuestionID = table.Column<int>(nullable: false),
                    OptionsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultichoiceQuestion_Options", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MultichoiceQuestion_Options_MultichoiceQuestion_MultichoiceQuestionID",
                        column: x => x.MultichoiceQuestionID,
                        principalTable: "MultichoiceQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultichoiceQuestion_Options_Options_OptionsID",
                        column: x => x.OptionsID,
                        principalTable: "Options",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultichoiceQuestion_OptionsAnswer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MultichoiceQuestionID = table.Column<int>(nullable: false),
                    OptionsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultichoiceQuestion_OptionsAnswer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MultichoiceQuestion_OptionsAnswer_MultichoiceQuestion_MultichoiceQuestionID",
                        column: x => x.MultichoiceQuestionID,
                        principalTable: "MultichoiceQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultichoiceQuestion_OptionsAnswer_Options_OptionsID",
                        column: x => x.OptionsID,
                        principalTable: "Options",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    OrganisationID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Survey_Organisation_OrganisationID",
                        column: x => x.OrganisationID,
                        principalTable: "Organisation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultichoiceQuestion_UsersOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MultichoiceQuestionID = table.Column<int>(nullable: false),
                    UsersOptionsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultichoiceQuestion_UsersOptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MultichoiceQuestion_UsersOptions_MultichoiceQuestion_MultichoiceQuestionID",
                        column: x => x.MultichoiceQuestionID,
                        principalTable: "MultichoiceQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultichoiceQuestion_UsersOptions_UsersOptions_UsersOptionsID",
                        column: x => x.UsersOptionsID,
                        principalTable: "UsersOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey_FreetextQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChapterID = table.Column<int>(nullable: true),
                    FreetextQuestionID = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey_FreetextQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Survey_FreetextQuestion_Chapters_ChapterID",
                        column: x => x.ChapterID,
                        principalTable: "Chapters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Survey_FreetextQuestion_FreetextQuestion_FreetextQuestionID",
                        column: x => x.FreetextQuestionID,
                        principalTable: "FreetextQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_FreetextQuestion_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey_MultichoiceQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChapterID = table.Column<int>(nullable: true),
                    MultichoiceQuestionID = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey_MultichoiceQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Survey_MultichoiceQuestion_Chapters_ChapterID",
                        column: x => x.ChapterID,
                        principalTable: "Chapters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Survey_MultichoiceQuestion_MultichoiceQuestion_MultichoiceQuestionID",
                        column: x => x.MultichoiceQuestionID,
                        principalTable: "MultichoiceQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_MultichoiceQuestion_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreetextAnswer_FreetextQuestionID",
                table: "FreetextAnswer",
                column: "FreetextQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_MultichoiceQuestion_Options_MultichoiceQuestionID",
                table: "MultichoiceQuestion_Options",
                column: "MultichoiceQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_MultichoiceQuestion_Options_OptionsID",
                table: "MultichoiceQuestion_Options",
                column: "OptionsID");

            migrationBuilder.CreateIndex(
                name: "IX_MultichoiceQuestion_OptionsAnswer_MultichoiceQuestionID",
                table: "MultichoiceQuestion_OptionsAnswer",
                column: "MultichoiceQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_MultichoiceQuestion_OptionsAnswer_OptionsID",
                table: "MultichoiceQuestion_OptionsAnswer",
                column: "OptionsID");

            migrationBuilder.CreateIndex(
                name: "IX_MultichoiceQuestion_UsersOptions_MultichoiceQuestionID",
                table: "MultichoiceQuestion_UsersOptions",
                column: "MultichoiceQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_MultichoiceQuestion_UsersOptions_UsersOptionsID",
                table: "MultichoiceQuestion_UsersOptions",
                column: "UsersOptionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_OrganisationID",
                table: "Survey",
                column: "OrganisationID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_FreetextQuestion_ChapterID",
                table: "Survey_FreetextQuestion",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_FreetextQuestion_FreetextQuestionID",
                table: "Survey_FreetextQuestion",
                column: "FreetextQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_FreetextQuestion_SurveyId",
                table: "Survey_FreetextQuestion",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_MultichoiceQuestion_ChapterID",
                table: "Survey_MultichoiceQuestion",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_MultichoiceQuestion_MultichoiceQuestionID",
                table: "Survey_MultichoiceQuestion",
                column: "MultichoiceQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_MultichoiceQuestion_SurveyID",
                table: "Survey_MultichoiceQuestion",
                column: "SurveyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreetextAnswer");

            migrationBuilder.DropTable(
                name: "MultichoiceQuestion_Options");

            migrationBuilder.DropTable(
                name: "MultichoiceQuestion_OptionsAnswer");

            migrationBuilder.DropTable(
                name: "MultichoiceQuestion_UsersOptions");

            migrationBuilder.DropTable(
                name: "Survey_FreetextQuestion");

            migrationBuilder.DropTable(
                name: "Survey_MultichoiceQuestion");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "UsersOptions");

            migrationBuilder.DropTable(
                name: "FreetextQuestion");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "MultichoiceQuestion");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Organisation");
        }
    }
}
