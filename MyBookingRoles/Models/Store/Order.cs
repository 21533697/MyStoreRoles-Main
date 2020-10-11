using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookingRoles.Models.Store
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        //[DisplayFormat(DataFormatString ="{0: yyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227: CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }


    }
}