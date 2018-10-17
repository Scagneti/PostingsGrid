namespace MockStaff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        BidId = c.Int(nullable: false, identity: true),
                        PostingId = c.Int(nullable: false),
                        PayRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BidId)
                .ForeignKey("dbo.Posting", t => t.PostingId, cascadeDelete: true)
                .Index(t => t.PostingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bid", "PostingId", "dbo.Posting");
            DropIndex("dbo.Bid", new[] { "PostingId" });
            DropTable("dbo.Bid");
        }
    }
}
