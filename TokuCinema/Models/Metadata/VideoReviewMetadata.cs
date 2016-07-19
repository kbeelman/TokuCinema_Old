using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoReview.Metadata))]
    public partial class VideoReview
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Video Review Id")]
            public System.Guid VideoReviewId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoreleaseId { get; set; }

            [Required]
            [Display(Name = "Introduction")]
            [DataType(DataType.MultilineText)]
            public string Introduction { get; set; }

            [Required]
            [Display(Name = "Presentation Comments")]
            [DataType(DataType.MultilineText)]
            public string PresentationComments { get; set; }

            [Required]
            [Display(Name = "Presentation Score")]
            public int PresentationScore { get; set; }

            [Required]
            [Display(Name = "Video Comments")]
            [DataType(DataType.MultilineText)]
            public string VideoComments { get; set; }

            [Required]
            [Display(Name = "Video Score")]
            public int VideoScore { get; set; }

            [Required]
            [Display(Name = "Audio Comments")]
            [DataType(DataType.MultilineText)]
            public string AudioComments { get; set; }

            [Required]
            [Display(Name = "Audio Score")]
            public int AudioScore { get; set; }

            [Required]
            [Display(Name = "Bonus Feature Comments")]
            [DataType(DataType.MultilineText)]
            public string BonusFeatureComments { get; set; }

            [Required]
            [Display(Name = "Bonus Feature Score")]
            public int BonusFeatureScore { get; set; }

            [Required]
            [Display(Name = "Verdict Comments")]
            [DataType(DataType.MultilineText)]
            public string VerdictComments { get; set; }

            [Required]
            [Display(Name = "Verdict Score")]
            public int VerdictScore { get; set; }

        }
    }
}
