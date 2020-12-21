namespace DEMO_BANHANG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        address = c.String(nullable: false, maxLength: 255),
                        phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.bills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        accountId = c.Int(nullable: false),
                        total = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false, storeType: "date"),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.accounts", t => t.accountId, cascadeDelete: true)
                .Index(t => t.accountId);
            
            CreateTable(
                "dbo.billdetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        billID = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        discount = c.Byte(),
                        sum_price = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false, storeType: "date"),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bills", t => t.billID, cascadeDelete: true)
                .ForeignKey("dbo.PRODUCTs", t => t.productId, cascadeDelete: true)
                .Index(t => t.billID)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.PRODUCTs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        author = c.String(nullable: false, maxLength: 255),
                        price = c.Int(nullable: false),
                        discount = c.Byte(),
                        images = c.String(maxLength: 255),
                        producerid = c.Int(),
                        catID = c.Int(),
                        description = c.String(),
                        status = c.Byte(nullable: false),
                        created_at = c.DateTime(),
                        category_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.category_id)
                .ForeignKey("dbo.producers", t => t.producerid)
                .Index(t => t.producerid)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        parent = c.Int(nullable: false),
                        status = c.Byte(nullable: false),
                        created_at = c.DateTime(nullable: false, storeType: "date"),
                        update_at = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.feedbacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productid = c.Int(nullable: false),
                        accountid = c.Int(nullable: false),
                        comment = c.String(nullable: false),
                        created_at = c.DateTime(nullable: false, storeType: "date"),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.accounts", t => t.accountid, cascadeDelete: true)
                .ForeignKey("dbo.PRODUCTs", t => t.productid, cascadeDelete: true)
                .Index(t => t.productid)
                .Index(t => t.accountid);
            
            CreateTable(
                "dbo.producers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRODUCTs", "producerid", "dbo.producers");
            DropForeignKey("dbo.feedbacks", "productid", "dbo.PRODUCTs");
            DropForeignKey("dbo.feedbacks", "accountid", "dbo.accounts");
            DropForeignKey("dbo.PRODUCTs", "category_id", "dbo.categories");
            DropForeignKey("dbo.billdetails", "productId", "dbo.PRODUCTs");
            DropForeignKey("dbo.billdetails", "billID", "dbo.bills");
            DropForeignKey("dbo.bills", "accountId", "dbo.accounts");
            DropIndex("dbo.feedbacks", new[] { "accountid" });
            DropIndex("dbo.feedbacks", new[] { "productid" });
            DropIndex("dbo.PRODUCTs", new[] { "category_id" });
            DropIndex("dbo.PRODUCTs", new[] { "producerid" });
            DropIndex("dbo.billdetails", new[] { "productId" });
            DropIndex("dbo.billdetails", new[] { "billID" });
            DropIndex("dbo.bills", new[] { "accountId" });
            DropTable("dbo.producers");
            DropTable("dbo.feedbacks");
            DropTable("dbo.categories");
            DropTable("dbo.PRODUCTs");
            DropTable("dbo.billdetails");
            DropTable("dbo.bills");
            DropTable("dbo.accounts");
        }
    }
}
