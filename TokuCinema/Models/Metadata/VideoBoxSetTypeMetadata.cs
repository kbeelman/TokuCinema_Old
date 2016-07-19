using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoBoxSetType.Metadata))]
    public partial class VideoBoxSetType
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Video Box Set Type Id")]
            public System.Guid VideoBoxSetTypeId { get; set; }

            [Required]
            [Display(Name = "Video Box Set Title")]
            [StringLength(100, ErrorMessage = "Please limit this field to 100 characters.")]
            public string VideoBoxSetTitle { get; set; }

            [Required]
            [Display(Name = "Video Box Set Description")]
            [DataType(DataType.MultilineText)]
            public string VideoBoxSetDescription { get; set; }
        }
    }
}