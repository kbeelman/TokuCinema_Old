using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoVersionType.Metadata))]
    public partial class VideoVersionType
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Video Version Type")]
            public System.Guid VideoVersionTypeId { get; set; }

            [Required]
            [Display(Name = "Video Version Title")]
            [StringLength(100, ErrorMessage = "Please limit this field to 100 characters.")]
            public string VideoVersionTitle { get; set; }

            [Required]
            [Display(Name = "Video Version Description")]
            public string VideoVersionDescription { get; set; }

            [Required]
            [Display(Name = "Video Media Id")]
            public System.Guid VideoMediaId { get; set; }


        }
    }
}
