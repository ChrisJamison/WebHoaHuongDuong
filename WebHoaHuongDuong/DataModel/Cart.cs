//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public Cart()
        {
            this.Bills = new HashSet<Bill>();
            this.CartDetails = new HashSet<CartDetail>();
        }
    
        public int Cart_ID { get; set; }
        public Nullable<int> Customer_ID { get; set; }
        public Nullable<System.DateTime> DateOfCreation { get; set; }
    
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
