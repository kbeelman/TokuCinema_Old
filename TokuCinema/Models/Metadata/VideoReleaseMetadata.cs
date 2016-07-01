using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoRelease.Metadata))]
    public partial class VideoRelease
    {
        [MetadataType(typeof(VideoRelease.Metadata))]
        class Metadata
        {
            [Key]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
            [Display(Name = "Distributor Id")]
            public System.Guid DistributorId { get; set; }

            [Required]
            [Display(Name = "Packaging Id")]
            public System.Guid PackagingId { get; set; }

            [Required]
            [Display(Name = "Shopping Item Id")]
            public System.Guid ShoppingItemId { get; set; }

            [Required]
            [Display(Name = "Video Media Id")]
            public System.Guid VideoMediaId { get; set; }

            [Required]
            [Display(Name = "Catalog Code")]
            public string CatalogCode { get; set; }

            [Required]
            [Display(Name = "UPC")]
            public string UPC { get; set; }

            [Required]
            [Display(Name = "Release Date")]
            public System.DateTime ReleaseDate { get; set; }

            [Required]
            [Display(Name = "Disc Count")]
            public int DiscCount { get; set; }

            [Required]
            [Display(Name = "Aspect Ratio")]
            public string AspectRatio { get; set; }

            [Required]
            [Display(Name = "Runtime (minutes)")]
            public int Runtime { get; set; }

            [Required]
            [Display(Name = "Chapter Stops")]
            public int ChapterStops { get; set; }
        }
    }
}
