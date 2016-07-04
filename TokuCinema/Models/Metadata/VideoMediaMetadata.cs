using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokuCinema.Models
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
            [Display(Name = "Original Aspect Ratio")]
            [StringLength(10, ErrorMessage = "Please limit this field to 10 characters.")]
            public string OriginalAspectRatio { get; set; }

            [Required]
            [Display(Name = "Original Runtime (minutes)")]
            public int OriginalRuntime { get; set; }

            [Required]
            [Display(Name = "Release Date")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime ReleaseDate { get; set; }

            [Required]
            [Display(Name = "Offical Title")]
            [StringLength(50, ErrorMessage = "Please limit this field to 100 characters.")]
            public string MediaOfficialTitle { get; set; }

            [Required]
            [Display(Name = "Media Description")]
            public string MediaDescription { get; set; }

            [Display(Name = "Wikipedia Link")]
            public string WikipediaLink { get; set; }

        }
    }
}
