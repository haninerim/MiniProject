namespace MiniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etablissements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEtabli = c.String(),
                        Adress = c.String(nullable: false),
                        Tel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        NameEtabli = c.String(),
                        Etablissement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etablissements", t => t.Etablissement_Id)
                .Index(t => t.Etablissement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "Etablissement_Id", "dbo.Etablissements");
            DropIndex("dbo.Etudiants", new[] { "Etablissement_Id" });
            DropTable("dbo.Etudiants");
            DropTable("dbo.Etablissements");
        }
    }
}
