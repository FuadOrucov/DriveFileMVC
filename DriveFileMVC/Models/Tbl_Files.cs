//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DriveFileMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Files
    {
        public int id { get; set; }
        public string FileName { get; set; }
        public int AccountId { get; set; }
        public string Attachment { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
    
        public virtual Tbl_Account Tbl_Account { get; set; }
    }
}