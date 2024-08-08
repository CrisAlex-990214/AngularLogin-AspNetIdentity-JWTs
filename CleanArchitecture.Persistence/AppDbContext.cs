using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence
{
    public class AppDbContext(DbContextOptions opts) : IdentityDbContext<User>(opts)
    {
    }
}
