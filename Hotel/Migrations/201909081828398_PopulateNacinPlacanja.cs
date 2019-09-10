namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNacinPlacanja : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO NacinPlacanjas ( Nacin) VALUES ( N'Kes')");
            Sql("INSERT INTO NacinPlacanjas ( Nacin) VALUES ( N'Kartica')");

        }
        
        public override void Down()
        {
        }
    }
}
