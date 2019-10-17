using System;
using System.Collections.Generic;
using System.Text;

namespace SmuleLib.Model
{
    public class ProfileData
    {
        public Meta meta { get; set; }
        public Pages Pages { get; set; }
        public Widgets Widgets { get; set; }
        public Loginstatus LoginStatus { get; set; }
        public Sitelinks SiteLinks { get; set; }
        public Sitebadges SiteBadges { get; set; }
        public string PublicApiHost { get; set; }
        public string AssetHost { get; set; }
    }

    public class Meta
    {
        public string mobile_title { get; set; }
    }

    public class Pages
    {
        public Home Home { get; set; }
        public object Duet { get; set; }
        public object Feed { get; set; }
        public object Listen { get; set; }
        public Playlist Playlist { get; set; }
        public object CreationPlayer { get; set; }
        public ProfileData Profile { get; set; }
        public object Settings { get; set; }
        public object PasswordReset { get; set; }
        public object SongBook { get; set; }
        public object Search { get; set; }
        public object ProfileEditor { get; set; }
        public object Song { get; set; }
        public object Composition { get; set; }
        public Billing Billing { get; set; }
        public object Recording { get; set; }
        public object Campfire { get; set; }
        public object CurationTool { get; set; }
        public object Globe { get; set; }
        public object SmuleFamily { get; set; }
    }

    public class Home
    {
        public bool playlists { get; set; }
        public bool campfireList { get; set; }
        public bool smuleFamilyList { get; set; }
    }

    public class Playlist
    {
        public bool currentPlaylist { get; set; }
    }

    public class Profile
    {
        public User user { get; set; }
        public Followingconfig followingConfig { get; set; }
        public Followingstatus followingStatus { get; set; }
        public string profilePerfUrl { get; set; }
        public string selectedPerfAppUid { get; set; }
        public Recommended_Recordings[] recommended_recordings { get; set; }
        public object[] recommended_users { get; set; }
        public string displayType { get; set; }
        public Displaydata displayData { get; set; }
        public Userblockaction userBlockAction { get; set; }
        public string selected_app_family { get; set; }
        public string[] installed_app_families { get; set; }
        public Recordings recordings { get; set; }
        public object arrangements { get; set; }
        public object profiles { get; set; }
        public int num_arrangements { get; set; }
        public string num_performances { get; set; }
        public Facebook_Settings facebook_settings { get; set; }
        public string num_favorites { get; set; }
        public Recommended_User_Playlist_Info recommended_user_playlist_info { get; set; }
        public string recommended_user_playlist_path { get; set; }
        public Recommended_Recordings_Playlist_Info recommended_recordings_playlist_info { get; set; }
        public string recommended_recordings_playlist_path { get; set; }
        public string canonical_url { get; set; }
    }

    public class User
    {
        public double account_id { get; set; }
        public string handle { get; set; }
        public string pic_url { get; set; }
        public string url { get; set; }
        public string followers { get; set; }
        public string followees { get; set; }
        public string num_performances { get; set; }
        public string blurb { get; set; }
        public bool is_following { get; set; }
        public bool is_vip { get; set; }
        public bool is_verified { get; set; }
        public string verified_type { get; set; }
        public int sfam_count { get; set; }
    }

    public class Followingconfig
    {
        public int accountId { get; set; }
        public string buttonContainer { get; set; }
        public string analyticsLabel { get; set; }
        public string statusUrl { get; set; }
    }

    public class Followingstatus
    {
        public bool isOwner { get; set; }
        public bool isFollowing { get; set; }
    }

    public class Displaydata
    {
        public object[] list { get; set; }
        public int next_offset { get; set; }
    }

    public class Userblockaction
    {
        public bool isBlocked { get; set; }
        public string isBlockedURL { get; set; }
        public string blockUrl { get; set; }
        public string unblockUrl { get; set; }
    }

    public class Recordings
    {
        public object[] list { get; set; }
        public int next_offset { get; set; }
    }

    public class Facebook_Settings
    {
        public Table table { get; set; }
    }

    public class Table
    {
        public string app_id { get; set; }
        public string _namespace { get; set; }
        public string url { get; set; }
        public string object_type { get; set; }
        public object title { get; set; }
        public string image { get; set; }
    }

    public class Recommended_User_Playlist_Info
    {
        public int id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public string app { get; set; }
        public string type { get; set; }
    }

    public class Recommended_Recordings_Playlist_Info
    {
        public int id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public string app { get; set; }
        public string type { get; set; }
    }

    public class Recommended_Recordings
    {
        public string key { get; set; }
        public string performance_key { get; set; }
        public object join_link { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        public object expire_at { get; set; }
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

    public class Billing
    {
    }

    public class Widgets
    {
        public object NationContent { get; set; }
        public string GlobalSearch { get; set; }
        public Login Login { get; set; }
        public Feed Feed { get; set; }
        public object Social { get; set; }
        public object SmartBanner { get; set; }
        public Fbsdk FbSdk { get; set; }
        public Footer Footer { get; set; }
        public Header Header { get; set; }
        public Autocompletesearch AutoCompleteSearch { get; set; }
        public Recaptcha Recaptcha { get; set; }
    }

    public class Login
    {
        public object auth { get; set; }
        public Init init { get; set; }
    }

    public class Init
    {
        public bool loggedIn { get; set; }
        public object embeddedPlayer { get; set; }
        public object currentUser { get; set; }
        public bool useCaptcha { get; set; }
        public Urls urls { get; set; }
        public object activationResult { get; set; }
        public object activationFromWeb { get; set; }
        public object activationApp { get; set; }
        public string pagePath { get; set; }
        public string fbAppId { get; set; }
        public string accountKitVersion { get; set; }
        public bool dauPeriodExeeded { get; set; }
    }

    public class Urls
    {
        public string standaloneLogin { get; set; }
        public string standalonePasswordReset { get; set; }
        public string login { get; set; }
        public string fblogin { get; set; }
        public string create { get; set; }
        public string passwordUpdate { get; set; }
        public string sendResetPasswordEmail { get; set; }
        public string sendActivation { get; set; }
        public string updateHandle { get; set; }
        public string account { get; set; }
        public string recordDau { get; set; }
        public string home { get; set; }
        public string checkEmail { get; set; }
        public string showOpt { get; set; }
        public string accountKit { get; set; }
    }

    public class Feed
    {
        public Feed_Status feed_status { get; set; }
        public bool stale { get; set; }
    }

    public class Feed_Status
    {
        public object last_check { get; set; }
        public object last_read { get; set; }
        public bool has_activity { get; set; }
        public bool is_vip { get; set; }
        public bool is_staff { get; set; }
        public object activity_count { get; set; }
        public bool has_sing { get; set; }
        public bool has_account_page { get; set; }
    }

    public class Fbsdk
    {
        public string appId { get; set; }
        public bool status { get; set; }
        public bool xfbml { get; set; }
        public string version { get; set; }
    }

    public class Footer
    {
        public int copyRightYear { get; set; }
        public bool show { get; set; }
    }

    public class Header
    {
        public bool show { get; set; }
    }

    public class Autocompletesearch
    {
        public string inputBackground { get; set; }
        public string searchPath { get; set; }
    }

    public class Recaptcha
    {
        public string sitekey { get; set; }
    }

    public class Loginstatus
    {
        public bool isLoggedIn { get; set; }
        public object handle { get; set; }
        public object picUrl { get; set; }
        public object session { get; set; }
        public bool campfireEnabled { get; set; }
    }

    public class Sitelinks
    {
        public string about { get; set; }
        public string jobs { get; set; }
        public string press { get; set; }
        public string contact { get; set; }
        public string communityguidelines { get; set; }
        public string termsofservice { get; set; }
        public string learnmore { get; set; }
        public string cookiepolicy { get; set; }
        public string acknowledgments { get; set; }
        public string copyright { get; set; }
        public string privacy { get; set; }
        public string campfire { get; set; }
        public string smuleFamily { get; set; }
        public string blog { get; set; }
        public string root { get; set; }
        public string listen { get; set; }
        public string songbook { get; set; }
        public string apps { get; set; }
        public string pricing { get; set; }
        public string billing { get; set; }
        public string support { get; set; }
        public string upload { get; set; }
        public string feeds { get; set; }
        public string my_profile { get; set; }
        public string userAccount { get; set; }
        public string billingAccount { get; set; }
        public string search { get; set; }
        public string user_login { get; set; }
        public string user_logout { get; set; }
    }

    public class Sitebadges
    {
        public string verified_basic { get; set; }
        public string verified_basic_white { get; set; }
        public string partner_artist { get; set; }
        public string partner_artist_white { get; set; }
        public string staff { get; set; }
    }
}
