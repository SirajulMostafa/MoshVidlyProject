using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoshVidlyProject.Models;

namespace MoshVidlyProject.ViewModel
{
    public class CreateCustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MemberShipType> MemberShipType { get; set; }
       
    }
}