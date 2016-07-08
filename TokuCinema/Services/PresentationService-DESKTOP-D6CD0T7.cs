using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokuCinema.Models;


namespace TokuCinema.Services 
{
	public static class PresentationService
	{
            // Dynamically generates a release name in the below format
            // {Year} {Distributor} Release for {List of Video Version Types}  
			public static string GetReleaseName(VideoRelease videoRelease)
			{
            // Data context
            TokuCinema_DataEntities db = new TokuCinema_DataEntities();

            // Stringbuilder
            StringBuilder sb = new StringBuilder();

            // Add year and distributor to stringbuilder
            sb.Append(string.Format("{0} {1} Release for ", videoRelease.ReleaseDate.Year, videoRelease.Distributor.DistributorName));

            // Get version type name for each version associated with this release and add its name to a list
            List<string> videoVersionNames = new List<string>();
            foreach (VideoVersion videoVersion in videoRelease.VideoVersions)
            {
                videoVersionNames.Add(db.VideoVersionTypes.Find(videoVersion.VideoVersionTypeId).VideoVersionTitle);
            }

            // Add those names to stringbuilder in the appropriate format
            if (videoVersionNames.Count == 1)
            {
                sb.Append(videoVersionNames.ElementAt(0));
            }
            else if(videoVersionNames.Count == 0)
            {
                sb.Append(" *No versions specified*");
            }
            else
            {
                for (int i = 0; i <= videoVersionNames.Count - 2; i++)
                {
                    sb.Append(videoVersionNames.ElementAt(i) + " | ");
                }
                sb.Append(videoVersionNames.ElementAt(videoVersionNames.Count - 1));
            }

            // Return constructed release name
            return sb.ToString();    				
			}
	}
}