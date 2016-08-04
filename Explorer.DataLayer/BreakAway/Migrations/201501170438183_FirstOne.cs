namespace Explorer.DataLayer.BreakAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "brk.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "brk.Trips",
                c => new
                    {
                        Identifier = c.Guid(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        CostUSD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DestinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier)
                .ForeignKey("brk.Locations", t => t.DestinationId, cascadeDelete: true)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "brk.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false, maxLength: 200),
                        Country = c.String(),
                        Description = c.String(maxLength: 500),
                        Photo = c.Binary(storeType: "image"),
                        TravelWarnings = c.String(),
                        ClimateInfo = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "brk.Lodgings",
                c => new
                    {
                        LodgingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Owner = c.String(),
                        MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
                        destination_id = c.Int(nullable: false),
                        PrimaryContactId = c.Int(),
                        SecondaryContactId = c.Int(),
                        MaxPersonsPerRoom = c.Int(),
                        PrivateRoomsAvailable = c.Boolean(),
                        Entertainment = c.String(),
                        Activities = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LodgingId)
                .ForeignKey("brk.Locations", t => t.destination_id, cascadeDelete: true)
                .ForeignKey("brk.People", t => t.PrimaryContactId)
                .ForeignKey("brk.People", t => t.SecondaryContactId)
                .Index(t => t.destination_id)
                .Index(t => t.PrimaryContactId)
                .Index(t => t.SecondaryContactId);
            
            CreateTable(
                "brk.InternetSpecials",
                c => new
                    {
                        InternetSpecialId = c.Int(nullable: false, identity: true),
                        Nights = c.Int(nullable: false),
                        CostUSD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        AccommodationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InternetSpecialId)
                .ForeignKey("brk.Lodgings", t => t.AccommodationId, cascadeDelete: true)
                .Index(t => t.AccommodationId);
            
            CreateTable(
                "brk.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        SocialSecurityNumber = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address_AddressId = c.Int(nullable: false),
                        StreetAddress = c.String(maxLength: 150),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Info_Weight_Reading = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Info_Weight_Units = c.String(),
                        Info_Height_Reading = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Info_Height_Units = c.String(),
                        Info_DietryRestrictions = c.String(),
                        Photo = c.Binary(storeType: "image"),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "brk.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        DateTimeMade = c.DateTime(nullable: false),
                        PaidInFull = c.DateTime(),
                        Traveler_PersonId = c.Int(),
                        Trip_Identifier = c.Guid(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("brk.People", t => t.Traveler_PersonId)
                .ForeignKey("brk.Trips", t => t.Trip_Identifier)
                .Index(t => t.Traveler_PersonId)
                .Index(t => t.Trip_Identifier);
            
            CreateTable(
                "brk.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        ReservationId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("brk.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId);
            
            CreateTable(
                "brk.TripActivities",
                c => new
                    {
                        Trip_Identifier = c.Guid(nullable: false),
                        Activity_ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trip_Identifier, t.Activity_ActivityId })
                .ForeignKey("brk.Trips", t => t.Trip_Identifier, cascadeDelete: true)
                .ForeignKey("brk.Activities", t => t.Activity_ActivityId, cascadeDelete: true)
                .Index(t => t.Trip_Identifier)
                .Index(t => t.Activity_ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("brk.Trips", "DestinationId", "brk.Locations");
            DropForeignKey("brk.Lodgings", "SecondaryContactId", "brk.People");
            DropForeignKey("brk.Lodgings", "PrimaryContactId", "brk.People");
            DropForeignKey("brk.Reservations", "Trip_Identifier", "brk.Trips");
            DropForeignKey("brk.Reservations", "Traveler_PersonId", "brk.People");
            DropForeignKey("brk.Payments", "ReservationId", "brk.Reservations");
            DropForeignKey("brk.InternetSpecials", "AccommodationId", "brk.Lodgings");
            DropForeignKey("brk.Lodgings", "destination_id", "brk.Locations");
            DropForeignKey("brk.TripActivities", "Activity_ActivityId", "brk.Activities");
            DropForeignKey("brk.TripActivities", "Trip_Identifier", "brk.Trips");
            DropIndex("brk.Trips", new[] { "DestinationId" });
            DropIndex("brk.Lodgings", new[] { "SecondaryContactId" });
            DropIndex("brk.Lodgings", new[] { "PrimaryContactId" });
            DropIndex("brk.Reservations", new[] { "Trip_Identifier" });
            DropIndex("brk.Reservations", new[] { "Traveler_PersonId" });
            DropIndex("brk.Payments", new[] { "ReservationId" });
            DropIndex("brk.InternetSpecials", new[] { "AccommodationId" });
            DropIndex("brk.Lodgings", new[] { "destination_id" });
            DropIndex("brk.TripActivities", new[] { "Activity_ActivityId" });
            DropIndex("brk.TripActivities", new[] { "Trip_Identifier" });
            DropTable("brk.TripActivities");
            DropTable("brk.Payments");
            DropTable("brk.Reservations");
            DropTable("brk.People");
            DropTable("brk.InternetSpecials");
            DropTable("brk.Lodgings");
            DropTable("brk.Locations");
            DropTable("brk.Trips");
            DropTable("brk.Activities");
        }
    }
}
