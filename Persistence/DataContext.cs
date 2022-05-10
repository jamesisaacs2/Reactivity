using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
   public class DataContext : DbContext
   {
      //added:
      public DataContext()
      {
      }

      public DataContext(DbContextOptions options) : base(options)
      {
      }

      //added:
      protected override void OnConfiguring(DbContextOptionsBuilder options)
      {
         if (!options.IsConfigured)
         {
            options.UseSqlite("A FALLBACK CONNECTION STRING");
         }
      }

      public DbSet<Activity> Activities { get; set; }
   }
}

/* Dev notes:

- dotnet ef migrations add InitialCreate -p Persistence -s API
- On migrations build, got error:  
Unable to create an object of type 'DataContext'. For the different patterns 
supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
- added ' //added ' to resolve
*/