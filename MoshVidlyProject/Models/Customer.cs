using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoshVidlyProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Customer Name should not be Empty  and String  max length 255  ")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

    }
}