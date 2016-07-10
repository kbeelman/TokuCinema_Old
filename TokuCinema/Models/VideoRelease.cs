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
    
    public partial class VideoRelease
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VideoRelease()
        {
            this.AudioTracks = new HashSet<AudioTrack>();
            this.Formats = new HashSet<Format>();
            this.MediaFiles = new HashSet<MediaFile>();
            this.Regions = new HashSet<Region>();
            this.ShoppingItems = new HashSet<ShoppingItem>();
            this.Standards = new HashSet<Standard>();
            this.SubtitleTracks = new HashSet<SubtitleTrack>();
            this.VideoBoxSets = new HashSet<VideoBoxSet>();
            this.VideoReviews = new HashSet<VideoReview>();
            this.VideoVersions = new HashSet<VideoVersion>();
        }
    
        public System.Guid VideoReleaseId { get; set; }
        public System.Guid DistributorId { get; set; }
        public System.Guid PackagingId { get; set; }
        public string CatalogCode { get; set; }
        public string UPC { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public int DiscCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AudioTrack> AudioTracks { get; set; }
        public virtual Distributor Distributor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Format> Formats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MediaFile> MediaFiles { get; set; }
        public virtual Packaging Packaging { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Region> Regions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingItem> ShoppingItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Standard> Standards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubtitleTrack> SubtitleTracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoBoxSet> VideoBoxSets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoReview> VideoReviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoVersion> VideoVersions { get; set; }
    }
}
