﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TokuCinema.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TokuCinema_DataEntities : DbContext
    {
        public TokuCinema_DataEntities()
            : base("name=TokuCinema_DataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AudioTrack> AudioTracks { get; set; }
        public virtual DbSet<AudioTrackType> AudioTrackTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<FormatType> FormatTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<MediaFile> MediaFiles { get; set; }
        public virtual DbSet<Packaging> Packagings { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RegionType> RegionTypes { get; set; }
        public virtual DbSet<ShoppingItemType> ShoppingItemTypes { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<StandardType> StandardTypes { get; set; }
        public virtual DbSet<SubtitleTrack> SubtitleTracks { get; set; }
        public virtual DbSet<SubtitleTrackType> SubtitleTrackTypes { get; set; }
        public virtual DbSet<VideoBoxSet> VideoBoxSets { get; set; }
        public virtual DbSet<VideoBoxSetType> VideoBoxSetTypes { get; set; }
        public virtual DbSet<VideoMedia> VideoMedias { get; set; }
        public virtual DbSet<VideoRelease> VideoReleases { get; set; }
        public virtual DbSet<VideoReview> VideoReviews { get; set; }
        public virtual DbSet<VideoShoppingItem> VideoShoppingItems { get; set; }
        public virtual DbSet<VideoVersion> VideoVersions { get; set; }
        public virtual DbSet<VideoVersionType> VideoVersionTypes { get; set; }
    }
}
