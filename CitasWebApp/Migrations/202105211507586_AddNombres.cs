namespace CitasWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNombres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombres", c => c.String());
            AddColumn("dbo.AspNetUsers", "Apellidos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Apellidos");
            DropColumn("dbo.AspNetUsers", "Nombres");
        }
    }
}
