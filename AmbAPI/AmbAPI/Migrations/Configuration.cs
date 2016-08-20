namespace AmbAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AmbAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AmbAPI.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AmbAPI.Models.MyContext context)
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
            //CreateDatabaseWithSeedData<MyContext>.LoadSeed(context); //��ʼ�����ݣ�ÿ��Ǩ�ƶ���ִ�У�����ע�ⲻ�õ�ʱ��Ҫע�͵�
        }
    }
}
