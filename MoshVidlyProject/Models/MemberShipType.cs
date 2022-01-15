using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoshVidlyProject.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        // here us readonly cz accedentally kokhono jodi modify kore feli compiled error ASVE
    }
}