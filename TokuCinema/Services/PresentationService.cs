using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TokuCinema.Models;
using TokuCinema.Domain;


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
            foreach (string versionName in videoVersionNames)
            {
                string seperator = "";

                if (versionName != videoVersionNames.Last())
                {
                    seperator = " | ";
                }                

                sb.Append(versionName + seperator);
            }
            
            // Return constructed release name
            return sb.ToString();
        }

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
      
        /*
         * Experimental - The goal is to create a reusable method that can get all records in a collection containing
                the key specified.
                Returns a list of associated records based on the passed arguments
        */
        public static List<IExposeProperty> GetRelativesOfListFromList(List<IExposeProperty> sourceCollection /*relatives from this collection*/, List<IExposeProperty> relatedCollection, string relatedKeyName)
        {
            // object to return
            List<IExposeProperty> relatives = new List<IExposeProperty>();

            // get relatives
            foreach (var relative in sourceCollection)
            {
                relatives.AddRange(relatedCollection.Where(id => id.ExposePropertyValue(relatedKeyName) == relative.ExposePropertyValue(relatedKeyName)));
            }

            // return children                  
            return relatives;
        }

        // Get all data for media decendents 
        public static MediaDecendents GetMediaDecendents(Guid mediaId)
        {
            // data context
            TokuCinema_DataEntities db = new TokuCinema_DataEntities();
            
            // return object
            MediaDecendents mediaDecendents = new MediaDecendents();

            // set video medias
            mediaDecendents.VideoMedias = db.VideoMedias.Where(id => id.MediaId == mediaId).ToList();

            // get and set version types
            //mediaDecendents.VideoVersionTypes = getVideoVersionTypesFromVideoMedia(mediaDecendents.VideoMedias, db.VideoVersionTypes.ToList());
            mediaDecendents.VideoVersionTypes = GetRelativesOfListFromList(mediaDecendents.VideoMedias.ToList<IExposeProperty>(), db.VideoVersionTypes.ToList<IExposeProperty>(), "VideoMediaId").ConvertAll(o => (VideoVersionType)o);

            // get and set video versions
            //mediaDecendents.VideoVersions = getVideoVersionsFromVersionTypes(mediaDecendents.VideoVersionTypes, db.VideoVersions.ToList());
            mediaDecendents.VideoVersions = GetRelativesOfListFromList(mediaDecendents.VideoVersionTypes.ToList<IExposeProperty>(), db.VideoVersions.ToList<IExposeProperty>(), "VideoVersionTypeId").ConvertAll(o => (VideoVersion)o);
          
            // set video releases
            List<VideoRelease> videoReleases = new List<VideoRelease>();
            List<VideoRelease> tempList = new List<VideoRelease>();

            // get and set temp list
            tempList = GetRelativesOfListFromList(mediaDecendents.VideoVersions.ToList<IExposeProperty>(), db.VideoReleases.ToList<IExposeProperty>(), "VideoReleaseId").ConvertAll(o => (VideoRelease)o);

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

        // Structure for decendents of video releases
        public struct ReleaseDecendents
        {
            public List<SubtitleTrack> SubtitleTracks { get; set; }
            public List<AudioTrack> AudioTracks { get; set; }
            public List<Region> Regions { get; set; }
            public List<MediaFile> MediaFiles { get; set; }
            public List<ShoppingItem> ShoppingItems { get; set; }
            public List<Standard> Standards { get; set; }
            public List<VideoBoxSet> VideoBoxSets { get; set; }
            public List<Format> Formats { get; set; }
            public List<VideoVersion> Versions { get; set; }
            public List<VideoReview> Reviews { get; set; }
        }

        public static ReleaseDecendents GetReleaseDecendents(Guid videoReleaseId)
        {
            // data context
            TokuCinema_DataEntities db = new TokuCinema_DataEntities();

            // object to return
            ReleaseDecendents releaseDecendents = new ReleaseDecendents();

            // subtitle tracks
            releaseDecendents.SubtitleTracks = db.SubtitleTracks.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // audio tracks
            releaseDecendents.AudioTracks = db.AudioTracks.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // regions
            releaseDecendents.Regions = db.Regions.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // media files
            releaseDecendents.MediaFiles = db.MediaFiles.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // Shopping items
            releaseDecendents.ShoppingItems = db.ShoppingItems.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // Standards
            releaseDecendents.Standards = db.Standards.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // Video box sets
            releaseDecendents.VideoBoxSets = db.VideoBoxSets.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // formats
            releaseDecendents.Formats = db.Formats.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // versions
            releaseDecendents.Versions = db.VideoVersions.Where(id => id.VideoReleaseId == videoReleaseId).ToList();

            // reviews
            releaseDecendents.Reviews = db.VideoReviews.Where(id => id.VideoreleaseId == videoReleaseId).ToList();

            // return the object
            return releaseDecendents;
        }
        
        //public static byte[] GetPrimaryMediaImage(Guid mediaId)
        //{
        //    // Context 
        //    TokuCinema_DataEntities db = new TokuCinema_DataEntities();
        //    VideoMedia firstVideoMedia = db.VideoMedias.Where(m => m.MediaId == mediaId).FirstOrDefault();
        //    VideoVersionType firstVersionType = db.VideoVersionTypes.Where(v => v.VideoMediaId == firstVideoMedia.VideoMediaId).FirstOrDefault();
        //    VideoVersion firstVideoVersion = db.VideoVersions.Where(v => v.VideoVersionTypeId == firstVersionType.VideoVersionTypeId).FirstOrDefault();
        //    VideoRelease firstRelease = db.VideoReleases.Where(v => v.VideoReleaseId == firstVideoVersion.VideoReleaseId).FirstOrDefault();
        //    try
        //    {
        //        byte[] returnFile = db.MediaFiles.Where(m => m.VideoReleaseId == firstRelease.VideoReleaseId).FirstOrDefault().MediaFile1;
        //        return returnFile;
        //    }
        //    catch (NullReferenceException)
        //    {

        //        throw new NullReferenceException();
        //    }
            
        //}

    }
}