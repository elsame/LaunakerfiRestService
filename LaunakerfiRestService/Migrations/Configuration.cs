namespace LaunakerfiRestService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LaunakerfiRestService.Models.SalarySystemDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LaunakerfiRestService.Models.SalarySystemDBContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LaunakerfiRestService.Models.SalarySystemDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
