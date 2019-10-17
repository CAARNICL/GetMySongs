using System;
using System.Collections.Generic;
using System.Text;

namespace SmuleLib.Model
{
    public class Favorites
    {
        public List[] list { get; set; }
        public int next_offset { get; set; }
    }

    public class List
    {
        public string key { get; set; }
        public string performance_key { get; set; }
        public object join_link { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? expire_at { get; set; }
        public bool seed { get; set; }
        public bool closed { get; set; }
        public string ensemble_type { get; set; }
        public int child_count { get; set; }
        public string app_uid { get; set; }
        public object arr_type { get; set; }
        public string arr_key { get; set; }
        public string song_id { get; set; }
        public object song_length { get; set; }
        public string perf_status { get; set; }
        public object artist_twitter { get; set; }
        public Orig_Track_City orig_track_city { get; set; }
        public string media_url { get; set; }
        public string video_media_url { get; set; }
        public string video_media_mp4_url { get; set; }
        public string cover_url { get; set; }
        public string web_url { get; set; }
        public object song_info_url { get; set; }
        public Stats stats { get; set; }
        public string performed_by { get; set; }
        public string performed_by_url { get; set; }
        public Owner owner { get; set; }
        public Other_Performers[] other_performers { get; set; }
        public Duet duet { get; set; }
        public Other other { get; set; }
        public bool featured { get; set; }
        public object rm { get; set; }
        public bool _private { get; set; }
        public object lyric_video { get; set; }
        public object lyrics { get; set; }
    }

    public class Orig_Track_City
    {
        public string city { get; set; }
        public string country { get; set; }
    }

    public class Stats
    {
        public int total_performers { get; set; }
        public string truncated_other_performers { get; set; }
        public int total_listens { get; set; }
        public string truncated_listens { get; set; }
        public int total_loves { get; set; }
        public string truncated_loves { get; set; }
        public int total_comments { get; set; }
        public string truncated_comments { get; set; }
        public int total_commenters { get; set; }
        public int total_gifts { get; set; }
        public string truncated_gifts { get; set; }
    }

    public class Owner
    {
        public double account_id { get; set; }
        public string handle { get; set; }
        public string pic_url { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string url { get; set; }
        public bool is_vip { get; set; }
        public bool is_verified { get; set; }
        public string verified_type { get; set; }
    }

    public class Duet
    {
        public long account_id { get; set; }
        public string handle { get; set; }
        public string pic_url { get; set; }
        public string url { get; set; }
        public bool is_vip { get; set; }
        public bool is_verified { get; set; }
        public string verified_type { get; set; }
    }

    public class Other
    {
        public string pic_url { get; set; }
        public string url { get; set; }
        public string verified_type { get; set; }
        public string label { get; set; }
        public bool vip { get; set; }
        public long? id { get; set; }
        public object verified_urls { get; set; }
    }

    public class Other_Performers
    {
        public long account_id { get; set; }
        public string handle { get; set; }
        public string pic_url { get; set; }
        public string url { get; set; }
        public bool is_vip { get; set; }
        public bool is_verified { get; set; }
        public string verified_type { get; set; }
    }
}
