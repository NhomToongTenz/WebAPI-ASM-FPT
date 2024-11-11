using ASM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASM.Appdatacontext;

public class AppDataContext : DbContext
{
    private DbSettings _dbContextSettings;

    public AppDataContext(IOptions<DbSettings> dbContextSettings) => _dbContextSettings = dbContextSettings.Value;

    // this DbSet will map to the Accounts table in the database
    public DbSet<Game_Mode> Game_Modes { get; set; }
    public DbSet<Player_GameMode> Player_GameMode { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Player_Resources> Player_Resources { get; set; }
    public DbSet<Resources> Resources { get; set; }

    // configure the connection to the database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_dbContextSettings.ConnectionString);

    // configure the rules with the tables in the database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game_Mode>()
            .ToTable("Game_Mode")
            .HasKey(k => k.GameMode_id);

        modelBuilder.Entity<Player_GameMode>()
            .ToTable("Player_GameModeController")
            .HasKey(k => k.Player_GameMode_id);

        modelBuilder.Entity<Items>()
            .ToTable("Item")
            .HasKey(k => k.Item_id);

        modelBuilder.Entity<Player>()
            .ToTable("Player")
            .HasKey(k => k.Player_id);

        modelBuilder.Entity<Player_Resources>()
            .ToTable("Player_Resources")
            .HasKey(k => k.Player_Resoucers_id);

        modelBuilder.Entity<Resources>()
            .ToTable("Resources")
            .HasKey(k => k.Resource_id);
    }
}
