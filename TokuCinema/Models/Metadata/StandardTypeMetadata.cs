using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(StandardType.Metadata))]
    public partial class StandardType
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Standard Type Id")]
            public System.Guid StandardTypeId { get; set; }

            [Required]
            [Display(Name = "Standard Name")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters")]
            public string StandardName { get; set; }

            [Required]
            [Display(Name = "Standard Description")]
            [DataType(DataType.MultilineText)]
            public string StandardDescription { get; set; }
        }
    }
}
