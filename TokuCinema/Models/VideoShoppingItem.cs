//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TokuCinema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VideoShoppingItem
    {
        public System.Guid VideoShoppingItemId { get; set; }
        public System.Guid ShoppingItemTypeId { get; set; }
        public System.Guid VideoReleaseId { get; set; }
    
        public virtual ShoppingItemType ShoppingItemType { get; set; }
        public virtual VideoRelease VideoRelease { get; set; }
    }
}
