//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPortfolio_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblProject
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Nullable<int> CategoryId { get; set; }
    
        public virtual TblCategory TblCategory { get; set; }
    }
}
