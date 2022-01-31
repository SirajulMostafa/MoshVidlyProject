using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MoshVidlyProject.Models
{
    public class ServicesContext: IdentityDbContext<IdentityUser>
    {
       public DbSet<Customer> Customers { get; set; }   
       public DbSet<MemberShipType> MemberShipTypes { get; set; }
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Genre> Genres { get; set; }

       public ServicesContext()
           : base("ServicesContext", throwIfV1Schema: false)
       {
       }

       public static ServicesContext Create()
       {
           return new ServicesContext();
       }
    }
}