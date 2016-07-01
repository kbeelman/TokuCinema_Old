using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoBoxSet.Metadata))]
    public partial class VideoBoxSet
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Video Box Set Id")]
            public System.Guid VideoBoxSetId { get; set; }

            [Required]
            [Display(Name = "Video Box Set Type Id")]
            public System.Guid VideoBoxSetTypeId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }
        }
    }
}
