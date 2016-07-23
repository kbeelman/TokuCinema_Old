using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TokuCinema.Models
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
            public System.Guid MediaFielId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
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

            [Required]
            [Display(Name ="Video Link")]
            public string VideoLink { get; set; }
        }
    }
}
