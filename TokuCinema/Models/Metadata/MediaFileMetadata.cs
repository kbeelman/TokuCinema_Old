using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(MediaFile.Metadata))]
    public partial class MediaFile
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Media Fiel Id")]
            public System.Guid MediaFielId { get; set; }

            [Required]
            [Display(Name = "VideoReleaseId")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
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
        }
    }
}
