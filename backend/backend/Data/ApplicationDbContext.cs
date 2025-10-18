using Microsoft.EntityFrameworkCore;


namespace backend.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> appointments { get; set; }
    public virtual DbSet<Car> cars { get; set; }
    public virtual DbSet<City> cities { get; set; }
    public virtual DbSet<Login> logins { get; set; }
    public virtual DbSet<Service> services { get; set; }
    public virtual DbSet<User> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Only configure if not already configured by DI
        if (!optionsBuilder.IsConfigured)
        {
            // Try environment variable first
            var conn = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            if (string.IsNullOrWhiteSpace(conn))
            {
                // Fallback - uses Session Pooler
                conn = "Host=aws-0-eu-north-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.brpdywzdxfnoxcxqkcnv;Password=jeoynk7QRf96kAg7;Timeout=30;Command Timeout=30";
            }
            if (!string.IsNullOrWhiteSpace(conn))
            {
                optionsBuilder.UseNpgsql(conn);
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("account_type", new[] { "USER", "SERVICE" });

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

