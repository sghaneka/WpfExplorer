using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.DataLayer.AngularJsForNetCourse.Migrations;
using Explorer.DomainClasses.BreakAway.Models;

namespace Explorer.DataLayer.BreakAway.Migrations
{
    public class BreakAwayConfiguration : DbMigrationsConfiguration<BreakAwayContext>
    {
        protected override void Seed(BreakAwayContext context)
        {
            var destination = new Destination
            {
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Name = "Bali"
            };
            context.Destinations.Add(destination);
            context.SaveChanges();
        }
    }
}
