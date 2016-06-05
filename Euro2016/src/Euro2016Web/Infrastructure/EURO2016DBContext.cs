using Euro2016Web.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Euro2016Web.Model
{
    public partial class EURO2016DBContext : DbContext
    {
        public EURO2016DBContext(DbContextOptions<EURO2016DBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Bet)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Bet_Match");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bet)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Bet_User");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.MatchCategory)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.MatchCategoryId)
                    .HasConstraintName("FK_Match_MatchCategory");

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.MatchTeam1)
                    .HasForeignKey(d => d.Team1Id)
                    .HasConstraintName("FK_Match_Team");

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.MatchTeam2)
                    .HasForeignKey(d => d.Team2Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Match_Team1");
            });

            modelBuilder.Entity<MatchCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Acronym)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Team_Group");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FriendlyUsername).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

        }

        public virtual DbSet<Bet> Bet { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchCategory> MatchCategory { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}