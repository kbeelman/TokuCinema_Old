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
    
    public partial class Packaging
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Packaging()
        {
            this.VideoReleases = new HashSet<VideoRelease>();
        }
    
        public System.Guid PackagingId { get; set; }
        public string PackagingDescription { get; set; }
        public string PackagingName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoRelease> VideoReleases { get; set; }
    }
}
