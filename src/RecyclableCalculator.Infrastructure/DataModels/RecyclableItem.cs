//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecyclableCalculator.Infrastructure.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecyclableItem
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public int RecyclableTypeId { get; set; }
    
        public virtual RecyclableType RecyclableType { get; set; }
    }
}