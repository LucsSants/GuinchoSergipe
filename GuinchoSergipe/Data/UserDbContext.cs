using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuinchoSergipe.Data;

public class UserDbContext : IdentityDbContext<UserModel>
{
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts) { }
    
}
