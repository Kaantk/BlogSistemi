using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class BlogSistemiContext
    : IdentityDbContext<ApplicationUser>
    {
        public BlogSistemiContext(DbContextOptions<BlogSistemiContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogLike> BlogLikes { get; set; }
        public DbSet<BlogView> BlogViews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<WebsiteSetting> WebsiteSettings { get; set; }
    }
}
