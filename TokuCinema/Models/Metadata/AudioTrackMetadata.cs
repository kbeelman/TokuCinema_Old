using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(AudioTrack.Metadata))]
    public partial class AudioTrack
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Audio Track Id")]
            public System.Guid AudioTrackid { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
            [Display(Name = "Language Id")]
            public System.Guid LanguageId { get; set; }

            [Required]
            [Display(Name = "Audio Track Name")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters")]
            public string AudioTrackName { get; set; }

            [Required]
            [Display(Name = "Audio Track Description")]
            public string AudioTrackDescription { get; set; }

            [Required]
            [Display(Name = "Channel")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters")]
            public string Channel { get; set; }
        }
    }
}
