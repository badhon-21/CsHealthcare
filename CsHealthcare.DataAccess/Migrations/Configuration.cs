namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CsHealthcare.DataAccess.AppDbContext>
    {
        public Configuration()
        {
              AutomaticMigrationsEnabled = false;
         }

        protected override void Seed(CsHealthcare.DataAccess.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.AspNetRoles.AddOrUpdate(
               p => p.Name,


                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Administrator" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "MsAdmin" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Application Admin" },

                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Purchase" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Inventory" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Sales" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Pharmacy Accounts" },

                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Front Desk Officer" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Doctor" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Nurse" },
                new AspNetRole { Id = Guid.NewGuid().ToString(), Name = "Nurse Manager" }

             );
        }
    }
}
