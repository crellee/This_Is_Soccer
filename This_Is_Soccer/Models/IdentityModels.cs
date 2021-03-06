﻿using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace This_Is_Soccer.Models
{


    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public static implicit operator ApplicationUser(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Entity.CountryModel> Countries { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<This_Is_Soccer.Models.Entity.ClubModel> ClubModels { get; set; }

        public System.Data.Entity.DbSet<This_Is_Soccer.Models.Entity.PositionModel> PositionModels { get; set; }

        public System.Data.Entity.DbSet<This_Is_Soccer.Models.Entity.PlayerModel> PlayerModels { get; set; }

        public DbSet<This_Is_Soccer.Models.Entity.MyTeamModel> MyTeamModels { get; set; }
    }
}