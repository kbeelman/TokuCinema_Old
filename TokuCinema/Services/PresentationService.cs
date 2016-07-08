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
                sb.Append(videoVersionNames.First());
            }
            else if(videoVersionNames.Count == 0)
            {
                sb.Append(" *No versions specified*");
            }
            else
            {
                for (int i = 0; i < videoVersionNames.Count - 2; i++)
                {
                    sb.Append(videoVersionNames.ElementAt(i) + " and ");
                }
                sb.Append(videoVersionNames.Last());
            }

            // Return constructed release name
            return sb.ToString();    				
			}

        //*Experimental - The goal is to create a reusable method that can get all records in a collection containing
        //                the key specified.  
        // Returns a list of associated records based on the passed arguments
        //public static List<T> GetRelatives(Guid objectKey, List<T> relatedCollection, string relatedKeyName)
        //{
        //    // object to return
        //    List<T> relatives = new List<T>();
     
        //    // get relatives
        //    foreach (var relative in relatedCollection.Where(id => id.GetType().GetProperty(relatedKeyName).GetValue() == objectKey))
        //    {
        //        relatives.Add(relative);
        //    }

        //    // return children                  
        //    return relatives;
        //}
        
        // Structure for decendents of media
        public struct MediaDecendents // :O <===8 
        {
            // child 
            public List<VideoMedia> VideoMedias {get; set;}
            // grand children 
            public List<VideoVersionType> VideoVersionTypes {get; set;}
            // great grand children
            public List<VideoVersion> VideoVersions {get; set;}
            // great grand in-law
            public List<VideoRelease> VideoReleases {get; set;}
        }
        
        // Get all data for media decendents  *TODO: this method is way to fucking long
        public static MediaDecendents GetMediaDecendents(Guid mediaId)
        {
            // data context
            TokuCinema_DataEntities db = new TokuCinema_DataEntities();
            
            // return object
            MediaDecendents mediaDecendents = new MediaDecendents();
            
            // set video medias
            mediaDecendents.VideoMedias = db.VideoMedias.Where(id => id.MediaId == mediaId).ToList();

            // get video version types
            List<VideoVersionType> videoVersionTypes = new List<VideoVersionType>();
            foreach (VideoMedia videoMedia in mediaDecendents.VideoMedias)
            {
                videoVersionTypes.AddRange(db.VideoVersionTypes.Where(id => id.VideoMediaId == videoMedia.VideoMediaId));
            }
            // set video version types
            mediaDecendents.VideoVersionTypes = videoVersionTypes;
            
            // get video versions
            List<VideoVersion> videoVersions = new List<VideoVersion>();
            foreach(VideoVersionType videoVersionType in mediaDecendents.VideoVersionTypes)
            {
                videoVersions.AddRange(db.VideoVersions.Where(id => id.VideoVersionTypeId == videoVersionType.VideoVersionTypeId));
            }            
            // set video versions
            mediaDecendents.VideoVersions = videoVersions;
            
            // get video releases
            List<VideoRelease> videoReleases = new List<VideoRelease>();
            List<VideoRelease> tempList = new List<VideoRelease>();
            foreach (VideoVersion videoVersion in mediaDecendents.VideoVersions)
            {
                tempList.AddRange(db.VideoReleases.Where(id => id.VideoReleaseId == videoVersion.VideoReleaseId));
            }

            // get ids from releases
            List<Guid> tempIdList = new List<Guid>();
            foreach (VideoRelease item in tempList)
            {
                tempIdList.Add(item.VideoReleaseId);
            }

            // add only distinct releases to the mediadecendects
            for (int i = 0; i < tempIdList.Distinct().Count(); i++)
            {
                videoReleases.Add(db.VideoReleases.Find(tempIdList[i]));
            }

            // set video releases
            mediaDecendents.VideoReleases = videoReleases;
            
            // return media decendents
            return mediaDecendents;
        }
        
    }
}