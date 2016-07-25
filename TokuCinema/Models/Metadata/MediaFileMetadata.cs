using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TokuCinema.Models.Metadata
{
    [MetadataType(typeof(MediaFile.Metadata))]
    public partial class MediaFile
    {
        // Used for file uploads
        public HttpPostedFileBase File { get; set; }
        class Metadata
        {
            [Key]
            [Display(Name = "Media File Id")]
            public System.Guid MediaFileId { get; set; }

            [Required]
            [Display(Name = "Video Version Id")]
            public System.Guid VideoVersionId { get; set; }

            [Display(Name = "Media File")]
            public byte[] MediaFile1 { get; set; }

            [Required]
            [Display(Name = "Is Image?")]
            public bool Image { get; set; }

            [Required]
            [Display(Name = "Is Video?")]
            public bool Video { get; set; }

            [Required]
            [Display(Name = "Location")]
            public int Location { get; set; }

            [Display(Name = "Media Link - If not file")]
            public string MediaLink { get; set; }

            [Required]
            [Display(Name = "Use image instead of file?")]
            public bool UseFileOverLink { get; set; }
        }
    }
}