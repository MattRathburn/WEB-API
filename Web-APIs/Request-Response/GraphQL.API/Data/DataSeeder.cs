using GraphQL.API.Entities;
using Bogus;

namespace GraphQL.API.Data;

public static class DataSeeder
{
    private static Faker f;
    public static void SeedData(BlogDbContext dbContext)
    {
        if (!dbContext.Posts.Any())
        {
            f = new Faker();
            for (int i = 1; i <= 10; i++)
            {
                var post = new Post
                {
                    Title = f.Lorem.Sentence(),
                    Content = f.Lorem.Paragraphs(3).FirstOrDefault().ToString(),
                    Author = f.Name.FullName(),
                    CreatedAt = DateTime.Now,
                };

                dbContext.Posts.Add(post);

                for (int j = 1; j <= 10; j++)
                {
                    var comment = new Comment
                    {
                        Content = f.Lorem.Sentence(),
                        Author = f.Name.FullName(),
                        CreatedAt = DateTime.Now,
                        Post = post
                    };

                    dbContext.Comments.Add(comment);
                }
            }
            dbContext.SaveChanges();
        }
    }
}