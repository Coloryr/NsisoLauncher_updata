using System.Collections.Generic;

namespace NsisoLauncher_updata
{
    class mod_re_obj
    {
        public string id { get; set; }
        public string game { get; set; }
        public string type { get; set; }
        public urls urls { get; set; }
        public List<file> files { get; set; }
        public List<link> links { get; set; }
        public string title { get; set; }
        public string donate { get; set; }
        public string license { get; set; }
        public List<member> members { get; set; }
        public version versions { get; set; }
        public downloads downloads { get; set; }
        public string thumbnail { get; set; }
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string description { get; set; }
        public string last_fetch { get; set; }

        public download download { get; set; }
    }
    class urls
    { 
        public string project { get; set; }
        public string curseforge { get; set; }
    }
    class file
    {
        public string id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string version { get; set; }
        public string filesize { get; set; }
        public List<string> versions { get; set; }
        public long downloads { get; set; }
        public string uploaded_at { get; set; }
    }
    class link
    { 
        public string href { get; set; }
        public string title { get; set; }
    }
    class member
    { 
        public string title { get; set; }
        public string username { get; set; }
    }
    class version
    {
        public Dictionary<string, List<file>> version_ { get; set; }
    }
    class downloads
    { 
        public long total { get; set; }
        public long monthly { get; set; }
    }
    class download : file
    {
        public new uploaded_at uploaded_at { get; set; }
    }
    class uploaded_at
    {
        public string date { get; set; }
        public long timezone_type { get; set; }
        public string timezone { get; set; }
    }

    class mod_re_obj1
    {
        public long id { get; set; }
        public string displayName { get; set; }
        public string fileName { get; set; }
        public string fileDate { get; set; }
        public long fileLength { get; set; }
        public int releaseType { get; set; }
        public int fileStatus { get; set; }
        public string downloadUrl { get; set; }
        public bool isAlternate { get; set; }
        public long alternateFileId { get; set; }
        public List<dependencie> dependencies { get; set; }
        public bool isAvailable { get; set; }
        public List<module> modules { get; set; }
        public long packageFingerprint { get; set; }
        public List<string> gameVersion { get; set; }
        public string installMetadata { get; set; }
        public string serverPackFileId { get; set; }
        public bool hasInstallScript { get; set; }
        public string gameVersionDateReleased {get;set;}
        public string gameVersionFlavor { get; set; }
    }
    class dependencie
    {
        public long addonId { get; set; }
        public int type { get; set; }
    }
    class module
    { 
        public string foldername { get; set; }
        public long fingerprint { get; set; }
    }
}
