namespace DEMO_BANHANG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_role_colum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.accounts", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.accounts", "role");
        }
    }
}
