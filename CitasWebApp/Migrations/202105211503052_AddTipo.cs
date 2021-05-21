namespace CitasWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "idTipo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "idTipo");
        }
    }
}
