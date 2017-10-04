using System;
using System.ComponentModel.DataAnnotations;

namespace Widly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        public MemberShipType MembershipType { get; set; }
        [Display(Name ="MemberShip Type")]
        [Required]
        public byte MembershipTypeId { get; set; }
    }
}