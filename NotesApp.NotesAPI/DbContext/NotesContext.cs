using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data.Models;
using NotesApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.NotesAPI.DbContext
{
    public class NotesContext : IdentityDbContext<User>
    {
        public NotesContext(DbContextOptions<NotesContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Image)
                    .HasColumnName("image"); 
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(n => n.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_modified");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id");

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Notes)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Note_User");
            });

            //Add Default Admin user and add its roles 

            var adminId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            //Seeding  roles to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData
            (
             new IdentityRole
             {
                 Id = adminId.ToString(),
                 ConcurrencyStamp = Guid.NewGuid().ToString(),
                 NormalizedName = Data.Enums.Roles.Admin.ToString().ToUpper(),
                 Name = Data.Enums.Roles.Admin.ToString()
             },
             new IdentityRole
             {
                 Id = Guid.NewGuid().ToString(),
                 ConcurrencyStamp = Guid.NewGuid().ToString(),
                 NormalizedName = Data.Enums.Roles.Moderator.ToString().ToUpper(),
                 Name = Data.Enums.Roles.Moderator.ToString()
             },
             new IdentityRole
             {
                 Id = Guid.NewGuid().ToString(),
                 ConcurrencyStamp = Guid.NewGuid().ToString(),
                 NormalizedName = Data.Enums.Roles.Basic.ToString().ToUpper(),
                 Name = Data.Enums.Roles.Basic.ToString()
             }
             );


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId.ToString(), // primary key
                    NormalizedUserName = "Admin",
                    NormalizedEmail = "Admin@gmail.com",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    FirstName = "Karan",
                    LastName = "singh",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "x12345x") // Should be read from Secrets server.
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminId.ToString(),
                    UserId = userId.ToString()
                }
            );
        }
    }
}
