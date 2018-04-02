namespace RexsReptileReviews.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RexsReptileReviews.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RexsReptileReviews.Models.ApplicationDbContext context)
        {
            context.reviews.AddOrUpdate(r => r.Title,
                new Models.Review()
                {
                    Author = "maryxbeth",
                    Title = "I love my Corn Snake!",
                    Reptile = Models.ReptileType.CornSnake,
                    Rating = 5,
                    ExperienceLevel = Models.ExperienceLevelType.Intermediate,
                    Body = "He's the best pet I've ever had! He is friendly, loves to cuddle, and has a huge personality."
                }
                );
        }
    }
}
