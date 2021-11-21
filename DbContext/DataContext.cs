using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using notelab.app.Model;

namespace notelab.app.DbContext
{
    public class DataContext:IdentityDbContext
    {
        public DataContext() {}
        public DataContext(DbContextOptions option):base(option) {}
        public virtual DbSet<Users> users {get; init;}
        public virtual DbSet<Notes> notes {get; init;}
    }
}
