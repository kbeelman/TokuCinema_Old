using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Medium.Metadata))]
    public partial class Medium
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Media Id")]
            public System.Guid MediaId { get; set; }

            [Required]
            [Display(Name = "Media Offical Title")]
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
