using LinkShortener.Models;
using Microsoft.EntityFrameworkCore;

public class LinkShortenerContext : DbContext
{
    public LinkShortenerContext(DbContextOptions<LinkShortenerContext> options)
        : base(options)
    {
    }

    public DbSet<Links> Links { get; set; }
}
