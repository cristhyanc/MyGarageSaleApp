//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Swoopinn.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCustomerBranch
    {
        public System.Guid IdBranch { get; set; }
        public System.Guid IdCustomer { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual tblBranch tblBranch { get; set; }
        public virtual tblCustomer tblCustomer { get; set; }
    }
}
