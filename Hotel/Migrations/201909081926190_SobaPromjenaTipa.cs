namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SobaPromjenaTipa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sobas", "Kvadratura", c => c.String());
            AlterColumn("dbo.Sobas", "Lezaj", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sobas", "Lezaj", c => c.Int(nullable: false));
            AlterColumn("dbo.Sobas", "Kvadratura", c => c.Int(nullable: false));
        }
    }
}
