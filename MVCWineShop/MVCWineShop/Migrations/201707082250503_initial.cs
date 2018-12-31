namespace MVCWineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Price = c.Double(nullable: false),
                        YearOfBottling = c.Int(nullable: false),
                        AlcoholPercentage = c.Double(nullable: false),
                        ImagePath = c.String(),
                        Description = c.String(),
                        WineType = c.Int(nullable: false),
                        WineryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Wineries", t => t.WineryId, cascadeDelete: true)
                .Index(t => t.WineryId);
            
            CreateTable(
                "dbo.Wineries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wines", "WineryId", "dbo.Wineries");
            DropIndex("dbo.Wines", new[] { "WineryId" });
            DropTable("dbo.Wineries");
            DropTable("dbo.Wines");
        }
    }
}
