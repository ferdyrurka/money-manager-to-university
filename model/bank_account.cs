//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoneyManagerToUniversity.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class bank_account
    {
        public int id { get; set; }
        public decimal current_ballance { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public int bank_id { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    
        public virtual bank bank { get; set; }
    }
}
