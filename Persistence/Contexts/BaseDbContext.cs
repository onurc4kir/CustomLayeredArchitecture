using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected IConfiguration Configuration { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            base.OnConfiguring(
                optionsBuilder.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection") ??
                    throw new ArgumentNullException()));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(a =>
        {
            a.ToTable("users").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("id");
            a.Property(p => p.FirstName).HasColumnName("first_name");
            a.Property(p => p.LastName).HasColumnName("last_name");
            a.Property(p => p.Email).HasColumnName("email");
            a.Property(p => p.PasswordHash).HasColumnName("password_hash");
            a.Property(p => p.PasswordSalt).HasColumnName("password_salt");
            a.Property(p => p.CreatedDate).HasColumnName("created_date");
            a.Property(p => p.IsActive).HasColumnName("is_active");
        });





        modelBuilder.Entity<RefreshToken>(a =>
        {
            a.ToTable("refresh_tokens").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("id");
            a.Property(p => p.UserId).HasColumnName("user_id");
            a.Property(p => p.Token).HasColumnName("token");
            a.Property(p => p.Expires).HasColumnName("expires");
            a.Property(p => p.CreatedByIp).HasColumnName("created_by_ip");
            a.Property(p => p.Revoked).HasColumnName("revoked");
            a.Property(p => p.RevokedByIp).HasColumnName("revoked_by_ip");
            a.Property(p => p.ReplacedByToken).HasColumnName("replaced_by_token");
            a.Property(p => p.CreatedDate).HasColumnName("created_date");
            a.Property(p => p.IsActive).HasColumnName("is_active");
            
            a.HasOne<User>(p => p.User);
        });

        modelBuilder.Entity<OperationClaim>(a =>
        {
            a.ToTable("operation_claims").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("id");
            a.Property(p => p.Name).HasColumnName("name");
            a.Property(p => p.CreatedDate).HasColumnName("created_date");
            a.Property(p => p.IsActive).HasColumnName("is_active");
        });
        modelBuilder.Entity<UserOperationClaim>(a =>
        {
            a.ToTable("user_operation_claims").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("id");
            a.Property(p => p.UserId).HasColumnName("user_id");
            a.Property(p => p.OperationClaimId).HasColumnName("operation_claim_id");
            a.Property(p => p.CreatedDate).HasColumnName("created_date");
            a.Property(p => p.IsActive).HasColumnName("is_active");

            a.HasOne<User>(p => p.User);
        });


        // Kid[] kidsSeed =
        // {
        //     new(new Guid("e1bfa146-6eaf-47f1-9165-8fc84d69c9cc"), "Kid 1", 12, hobbies: null, petName: null,
        //         gender: null),
        //     new(new Guid("8353a545-0998-43c0-a070-dc8cfc16bdd8"), "Kid 2", 7, hobbies: "football,movie",
        //         petName: "kont", gender: true)
        // };
        // modelBuilder.Entity<Kid>().HasData(kidsSeed);
    }
}