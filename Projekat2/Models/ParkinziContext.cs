using Microsoft.EntityFrameworkCore;
namespace Projekat.Models
{
    public class ParkinziContext: DbContext
    {
      public DbSet<Parkinzi> Park { get; set;}
      public DbSet<Parking> JedanParking{ get; set;}
      public DbSet<Mesta> Mesto{get;set;}
      public ParkinziContext(DbContextOptions options ) : base(options)
      {
        
      }
    }
}