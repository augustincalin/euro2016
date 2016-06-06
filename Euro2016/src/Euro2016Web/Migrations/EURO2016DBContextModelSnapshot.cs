using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Euro2016Web.Model;

namespace Euro2016Web.Migrations
{
    [DbContext(typeof(EURO2016DBContext))]
    partial class EURO2016DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Euro2016Web.Core.Model.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MatchId");

                    b.Property<int?>("PointsGained");

                    b.Property<int?>("Score1");

                    b.Property<int?>("Score2");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("UserId");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<bool?>("IsPlaceholder");

                    b.Property<int>("MatchCategoryId");

                    b.Property<int?>("Score1");

                    b.Property<int?>("Score2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Team1Id");

                    b.Property<int>("Team2Id");

                    b.HasKey("Id");

                    b.HasIndex("MatchCategoryId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.MatchCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("MatchCategory");
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsPlaceholder");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FriendlyUsername")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("TotalPoints");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.Bet", b =>
                {
                    b.HasOne("Euro2016Web.Core.Model.Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .HasConstraintName("FK_Bet_Match")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Euro2016Web.Core.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Bet_User")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.Match", b =>
                {
                    b.HasOne("Euro2016Web.Core.Model.MatchCategory")
                        .WithMany()
                        .HasForeignKey("MatchCategoryId")
                        .HasConstraintName("FK_Match_MatchCategory")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Euro2016Web.Core.Model.Team")
                        .WithMany()
                        .HasForeignKey("Team1Id")
                        .HasConstraintName("FK_Match_Team")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Euro2016Web.Core.Model.Team")
                        .WithMany()
                        .HasForeignKey("Team2Id")
                        .HasConstraintName("FK_Match_Team1");
                });

            modelBuilder.Entity("Euro2016Web.Core.Model.Team", b =>
                {
                    b.HasOne("Euro2016Web.Core.Model.Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Team_Group");
                });
        }
    }
}
