using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Explorer.DataLayer.BreakAway;
using Explorer.DataLayer.BreakAway.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Explorer.DataLayer.Test.BreakAway
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BreakAwayContext, BreakAwayConfiguration>());
            var configuration = new Explorer.DataLayer.BreakAway.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            //Rollback
            migrator.Update("0");

            // Go To First Migration
            migrator.Update("FirstOne");
            
        }

        [TestMethod]
        public void QueryAllTheDataFromASet()
        {
            using (var ctx = new BreakAwayContext())
            {
                foreach (var destination in ctx.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
            Console.WriteLine("Done");
        }

        [TestMethod]
        public void QueryAllTheDataSorted()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            orderby d.Name
                            select d;

                foreach (var destination in query)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        [TestMethod]
        public void QueryUsingFind()
        {
            using (var context = new BreakAwayContext())
            {
                // 2 should be there
                var destination = context.Destinations.Find(2);
                Assert.IsNotNull(destination);
                // 25 should not be there
                destination = context.Destinations.Find(24);
                Assert.IsNull(destination);
            }
        }

        // Local stores in memory data
        // Initially its 0

        [TestMethod]
        public void LocalTests()
        {
            using (var context = new BreakAwayContext())
            {
                var count = context.Destinations.Local.Count;
                // Nothing loaded initially, so count is 0
                Assert.AreEqual(0, count);
            }

            using (var context = new BreakAwayContext())
            {
                foreach (var destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }

                var count = context.Destinations.Local.Count;
                // Now it's greater than 0
                Assert.IsTrue(count > 0);
            }

            using (var context = new BreakAwayContext())
            {
                context.Destinations.Load(); // Loading in memory is better than iterating..

                var count = context.Destinations.Local.Count;
                // Now it's greater than 0
                Assert.IsTrue(count > 0);

                // We can query against Local too
                var sortedDestinations = from d in context.Destinations.Local
                                         orderby d.Name
                                         select d;

                Console.WriteLine("All Destinations: (using local)");
                foreach (var destination in sortedDestinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }
    }
}
