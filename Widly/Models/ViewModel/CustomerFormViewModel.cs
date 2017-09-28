using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widly.Models.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}