using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityWebAPI.Data.Entities;

namespace IdentityWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}
