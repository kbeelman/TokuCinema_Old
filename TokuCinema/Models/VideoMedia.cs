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
    
    public partial class VideoMedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VideoMedia()
        {
            this.VideoReleases = new HashSet<VideoRelease>();
        }
    
        public System.Guid VideoMediaId { get; set; }
        public System.Guid MediaId { get; set; }
        public string OriginalAspectRatio { get; set; }
        public System.TimeSpan OriginalRuntime { get; set; }
    
        public virtual Media Medium { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoRelease> VideoReleases { get; set; }
    }
}
