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
    
    public partial class Customer
    {
        public Customer()
        {
            this.Carts = new HashSet<Cart>();
        }
    
        public int Customer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> LastDateAccess { get; set; }
        public string IdentifyCardNumber { get; set; }
        public string Email { get; set; }
    
        public virtual ICollection<Cart> Carts { get; set; }
    }
}