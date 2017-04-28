namespace MapEgora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photocreated = c.DateTime(nullable: false),
                        Description = c.String(),
                        PhotoName = c.String(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            AddColumn("dbo.Routes", "RouteKML", c => c.String(nullable: false));
            AlterColumn("dbo.Routes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Routes", "RouteImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "RouteId", "dbo.Routes");
            DropIndex("dbo.Photos", new[] { "RouteId" });
            AlterColumn("dbo.Routes", "RouteImage", c => c.String());
            AlterColumn("dbo.Routes", "Name", c => c.String());
            DropColumn("dbo.Routes", "RouteKML");
            DropTable("dbo.Photos");
        }
    }
}
