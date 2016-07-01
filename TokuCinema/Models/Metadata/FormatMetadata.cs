using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Format.Metadata))]
    public partial class Format
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Format Id")]
            public System.Guid FormatId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
            [Display(Name = "Format Type Id")]
            public System.Guid FormatTypeId { get; set; }

        }
    }
}
