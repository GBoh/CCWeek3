namespace ContactManager.Migrations
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.DataContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public string LastName(Random rnd)
        {
            string last;
            string[] LastArr = { "Johnson", "Bohanon", "Smith", "Jones", "Young", "Lopez", "Huber", "Mario", "Barboza", "Hoffmann" };

            last = LastArr[rnd.Next(LastArr.Length)];
            return last;
        }

        public string FirstName(Random rnd)
        {
            string first;
            string[] FirstArr = { "Cave", "John", "Joe", "Greg", "Sara", "Kelly", "Steve", "Mario", "Paul", "Bob" };

            first = FirstArr[rnd.Next(FirstArr.Length)];
            return first;
        }

        public DateTime RandomDoB(Random rnd)
        {
            DateTime birthday = DateTime.Now;

            return birthday.AddDays(rnd.Next(0, 100000));
        }

        public string RandomPhone(Random rnd)
        {
            StringBuilder phone = new StringBuilder();
            phone.Clear();
            for (int i = 0; i < 10; i++)
            {
                phone.Append(rnd.Next(1, 9));
            }
            return phone.ToString();
        }

        protected override void Seed(ContactManager.Models.DataContext context)
        {
            List<Contact> Contacts = new List<Contact>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                Contacts.Add(new Contact()
                {
                    FirstName = FirstName(rnd),
                    LastName = LastName(rnd),
                    Birthday = RandomDoB(rnd),
                    PhoneNumber = RandomPhone(rnd)
                });
            }

            Contacts.ForEach(c => context.Contacts.AddOrUpdate(c));
            context.SaveChanges();


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
        }
    }
}
