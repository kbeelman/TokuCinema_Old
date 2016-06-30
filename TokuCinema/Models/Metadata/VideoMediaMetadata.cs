using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokuCinema.Models.Metadata
{
    [MetadataType(typeof(VideoMedia.Metadata))]
    public partial class VideoMedia
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Video Media Id")]
            public System.Guid VideoMediaId { get; set; }

            [Required]
            [Display(Name = "Media Id")]
            public System.Guid MediaId { get; set; }

            [Required]
            [Display(Name = "Original Aspect Ration")]
            [StringLength(10, ErrorMessage = "Please limit this field to 10 characters.")]
            public string OriginalAspectRatio { get; set; }

            [Required]
            [Display(Name = "Original Runtime")]
            public System.TimeSpan OriginalRuntime { get; set; }
        }
    }
}
