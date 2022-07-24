using Chatroom.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// DB Context to handle authenticated users.
/// </summary>
public class ChatroomContext : IdentityDbContext<ChatroomUser, IdentityRole, string>
{
    public ChatroomContext(DbContextOptions<ChatroomContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
