using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using backend.Models.Scaffolded;

namespace backend.Data.Scaffolded;

public partial class SupabaseDbContext : DbContext
{
    public SupabaseDbContext(DbContextOptions<SupabaseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> appointments { get; set; }

    public virtual DbSet<Car> cars { get; set; }

    public virtual DbSet<City> cities { get; set; }

    public virtual DbSet<Login> logins { get; set; }

    public virtual DbSet<Service> services { get; set; }

    public virtual DbSet<User> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("account_type", new[] { "USER", "SERVICE" })
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => new { e.car_id, e.service_id }).HasName("appointments_pk");

            entity.HasOne(d => d.car).WithMany(p => p.appointments).HasConstraintName("appointments_car_fk");

            entity.HasOne(d => d.service).WithMany(p => p.appointments).HasConstraintName("appointments_service_fk");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.id).HasName("cars_pkey");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.owner).WithMany(p => p.cars)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cars_owner_fk");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.id).HasName("city_pkey");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
        }); 

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.id).HasName("login_pkey");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.id).HasName("services_pkey");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.can_itp).HasDefaultValue(false);

            entity.HasOne(d => d.city).WithMany(p => p.services).HasConstraintName("services_city_id_fkey");

            entity.HasOne(d => d.idNavigation).WithOne(p => p.service).HasConstraintName("services_login_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.id).HasName("users_pkey");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.idNavigation).WithOne(p => p.user).HasConstraintName("users_login_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
