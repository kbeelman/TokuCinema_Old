using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(SubtitleTrack.Metadata))]
    public partial class SubtitleTrack
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Subtitle Track Id")]
            public System.Guid SubtitleTrackId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
            [Display(Name = "Language Id")]
            public System.Guid LanguageId { get; set; }

            [Required]
            [Display(Name = "Subtitle Track Name")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters.")]
            public string SubtitleTrackName { get; set; }

            [Required]
            [Display(Name = "Subtitle Track Description")]
            public string SubtitleTrackDescription { get; set; }
        }
    }
}
