namespace proje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSiparislerKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Siparislers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TurId = c.Int(nullable: false),
                        Isim = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        Kisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Siparislers");
        }
    }
}
