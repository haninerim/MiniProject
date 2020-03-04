namespace MiniProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MiniProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniProject.Models.MiniProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MiniProject.Models.MiniProjectContext context)
        {
            context.Etablissements.AddOrUpdate(x => x.Id,
         new Etablissement() {Id=1, NameEtabli = "Istic", Adress = "hanine", Tel = 12523 },
         new Etablissement() { Id=2 ,NameEtabli = "ESPRIT", Adress = "Rim", Tel = 51619 });

            context.Etudiants.AddOrUpdate(x => x.Id,
         new Etudiant() { Id = 1, FirstName = "hanine", LastName="zayani", NameEtabli="Istic" },
         new Etudiant() { Id = 2, FirstName = "Rim", LastName="kourou", NameEtabli = "Istic" },
         new Etudiant() { Id = 3, FirstName = "Anwer", LastName="Zayani", NameEtabli = "ESPRIT" }
         );
        }
    }
}
