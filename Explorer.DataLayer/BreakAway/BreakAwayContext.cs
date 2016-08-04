using System.Data.Entity;
using Explorer.DomainClasses.BreakAway.Models;

namespace Explorer.DataLayer.BreakAway
{
  public class BreakAwayContext : DbContext
  {
    public DbSet<Destination> Destinations { get; set; }

    public DbSet<Lodging> Lodgings { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Activity> Activities { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("brk");
    }


    
  }
}