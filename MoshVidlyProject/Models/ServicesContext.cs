using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoshVidlyProject.Models
{
    public class ServicesContext:DbContext
    {
       public DbSet<Customer> Customers { get; set; }   
       public DbSet<MemberShipType> MemberShipTypes { get; set; }   
    }
}