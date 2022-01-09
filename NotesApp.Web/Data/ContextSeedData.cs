using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NotesApp.Data.Models;
using NotesApp.Web.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.Web.Data
{
    public class ContextSeedData
    {
        private NotesContext dbcontext;

        public ContextSeedData(NotesContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async void SeedAdminUser()
        {

            var user = new User
            {
                NormalizedUserName = "Admin",
                NormalizedEmail = "Admin@gmail.com",
                Email = "admin@gmail.com",
                UserName = "admin",
                FirstName = "Karan",
                LastName = "singh",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(this.dbcontext);

            if (!this.dbcontext.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            var userStore = new UserStore<User>(this.dbcontext);

            if (!this.dbcontext.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "password");
                user.PasswordHash = hashed;
              
                var result =   await userStore.CreateAsync(user); 
            }

            await this.dbcontext.SaveChangesAsync();
        }
    }
}
