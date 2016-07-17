using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TokuCinema.Models;

namespace TokuCinema.Controllers
{
    public class VideoReleasesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoReleases
        public ActionResult Index()
        {
            var videoReleases = db.VideoReleases.Include(v => v.Distributor).Include(v => v.Packaging);
            return View(videoReleases.ToList());
        }

        // GET: VideoReleases/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            if (videoRelease == null)
            {
                return HttpNotFound();
            }
            return View(videoRelease);
        }

        // GET: VideoReleases/Create
        public ActionResult Create()
        {
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName");
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingName");
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "Medium.MediaOfficialTitle");
            return View();
        }

        // GET: Video Media Used with JavaScript/Ajax script
        public PartialViewResult GetVideoMedia()
        {
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "Medium.MediaOfficialTitle");
            return PartialView("_VideoMediaList");
        }

        #region Ajax PartialViewResults
        // GET: Versions
        public PartialViewResult GetVersions(string id)
        {
            //List<VideoVersionType> videoVersionTypes = db.VideoVersionTypes.Where(v => v.VideoMediaId.ToString() == id).ToList();
            ViewBag.VideoVersionTypeId = new SelectList(db.VideoVersionTypes.Where(v => v.VideoMediaId.ToString() == id), "VideoVersionTypeId", "VideoVersionTitle");
            return PartialView("_VideoVersionTypeList");
        }

        // GET: Regions 
        public PartialViewResult GetRegions()
        {
            ViewBag.RegionTypeId = new SelectList(db.RegionTypes, "RegionTypeId", "RegionName");
            return PartialView("_RegionTypeList");
        }

        // GET: Box Sets
        public PartialViewResult GetBoxSets()
        {
            ViewBag.VideoBoxSetTypeId = new SelectList(db.VideoBoxSetTypes, "VideoBoxSetTypeId", "VideoBoxSetTitle");
            return PartialView("_VideoBoxSetTypeList");
        }
        
        // GET: Standards
        public PartialViewResult GetStandards()
        {
            ViewBag.StandardTypeId = new SelectList(db.StandardTypes, "StandardTypeId", "StandardName");
            return PartialView("_StandardTypeList");
        }

        // GET: Formats
        public PartialViewResult GetFormats()
        {
            ViewBag.FormatTypeId = new SelectList(db.FormatTypes, "FormatTypeId", "FormatName");
            return PartialView("_FormatTypeList");
        }
        #endregion

        // POST: VideoReleases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoReleaseId,DistributorId,PackagingId,CatalogCode,UPC,ReleaseDate,DiscCount")] VideoRelease videoRelease)
        {
            if (ModelState.IsValid)
            {
                videoRelease.VideoReleaseId = Guid.NewGuid();
                db.VideoReleases.Add(videoRelease);

                #region Add Children
                // Add selected versions
                string stringNumOfVersions = Request["numberOfVersions"];
                int numberOfVersions = Int32.Parse(stringNumOfVersions);
                for (int i = 1; i <= numberOfVersions; i++)
                {
                    VideoVersion videoVersion = new VideoVersion();
                    videoVersion.VideoVersionId = Guid.NewGuid();
                    videoVersion.VideoReleaseId = videoRelease.VideoReleaseId;
                    videoVersion.VideoVersionTypeId = Guid.Parse(Request["selectedVersion" + i]);
                    db.VideoVersions.Add(videoVersion);
                }

                // Add selected regions
                string stringNumOfRegions = Request["numberOfRegions"];
                int numberOfRegions;
                bool regionsExist = Int32.TryParse(stringNumOfRegions, out numberOfRegions);
                if (regionsExist)
                {
                    for (int i = 1; i <= numberOfRegions; i++)
                    {
                        Region region = new Region();
                        region.RegionId = Guid.NewGuid();
                        region.VideoReleaseId = videoRelease.VideoReleaseId;
                        region.RegionTypeId = Guid.Parse(Request["selectedRegion" + i]);
                        db.Regions.Add(region);
                    }
                }

                // Add selected box sets
                string stringNumOfBoxSets = Request["numberOfBoxSets"];
                int numberOfBoxSets;
                bool boxSetsExist = Int32.TryParse(stringNumOfBoxSets, out numberOfBoxSets);
                if (boxSetsExist)
                {
                    for (int i = 1; i <= numberOfBoxSets; i++)
                    {
                        VideoBoxSet boxSet = new VideoBoxSet();
                        boxSet.VideoBoxSetId = Guid.NewGuid();
                        boxSet.VideoReleaseId = videoRelease.VideoReleaseId;
                        boxSet.VideoBoxSetTypeId = Guid.Parse(Request["selectedBoxSet" + i]);
                        db.VideoBoxSets.Add(boxSet);
                    }
                }

                // Add selected standard
                string stringNumOfStandards = Request["numberOfStandards"];
                int numberOfStandards;
                bool standardsExist = Int32.TryParse(stringNumOfStandards, out numberOfStandards);
                if (standardsExist)
                {
                    for (int i = 1; i <= numberOfStandards; i++)
                    {
                        Standard standard = new Standard();
                        standard.StandardId= Guid.NewGuid();
                        standard.VideoReleaseId = videoRelease.VideoReleaseId;
                        standard.StandardTypeID = Guid.Parse(Request["selectedStandard" + i]);
                        db.Standards.Add(standard);
                    }
                }

                // Add selected format
                string stringNumOfFormats = Request["numberOfFormats"];
                int numberOfFormats;
                bool formatsExist = Int32.TryParse(stringNumOfFormats, out numberOfFormats);
                if (formatsExist)
                {
                    for (int i = 1; i <= numberOfFormats; i++)
                    {
                        Format format = new Format();
                        format.FormatId = Guid.NewGuid();
                        format.VideoReleaseId = videoRelease.VideoReleaseId;
                        format.FormatTypeId = Guid.Parse(Request["selectedFormat" + i]);
                        db.Formats.Add(format);
                    }
                }
                #endregion

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingName", videoRelease.PackagingId);
            return View(videoRelease);
        }


        // GET: VideoReleases/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            if (videoRelease == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingDescription", videoRelease.PackagingId);
            return View(videoRelease);
        }

        // POST: VideoReleases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoReleaseId,DistributorId,PackagingId,CatalogCode,UPC,ReleaseDate,DiscCount")] VideoRelease videoRelease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoRelease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingDescription", videoRelease.PackagingId);
            return View(videoRelease);
        }

        // GET: VideoReleases/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            if (videoRelease == null)
            {
                return HttpNotFound();
            }
            return View(videoRelease);
        }

        // POST: VideoReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            db.VideoReleases.Remove(videoRelease);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
