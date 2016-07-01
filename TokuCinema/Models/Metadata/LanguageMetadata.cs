using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Language.Metadata))]
    public partial class Language
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Language Id")]
            public System.Guid LanguageId { get; set; }

            [Required]
            [Display(Name = "Language Name")]
            [StringLength(15, ErrorMessage = "Please limit this field to 15 characters.")]
            public string LanguageName { get; set; }
        }
    }
}
