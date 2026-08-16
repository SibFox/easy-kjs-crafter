using Godot;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace EasyKJSCrafter.ResourceClasses
{
    [GlobalClass]
    [DebuggerDisplay("Mod = {_modId}, Path = {_path}")]
    public partial class PathId : Resource
    {
        private string _modId = "minecraft";
        private string _path = "air";
        
        [Export]
        public string ModId { 
            get { return _modId; }
            set
            {
                if (ModIdRegex().IsMatch(value))
                    _modId = value.ToLower();
            }
        }
        [Export]
        public string Path { 
            get { return _path; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                
                string cleaned = value.Trim('/');
                cleaned = Regex.Replace(cleaned, @"/+", "/");

                if (PathRegex().IsMatch(cleaned))
                    _path = cleaned.ToLower();
            }
        }

        [Export]
        public string WholePath
        {
            get { return _modId + ":" + _path; }
            set { SetPathFromWholePath(value); }
        }

        public PathId() {}
        public PathId(string modId, string path)
        {
            ModId = modId;
            Path = path;
        }
        public PathId(string wholePath) { SetPathFromWholePath(wholePath); }

        public void SetPathFromWholePath(string wholePath)
        {
            string[] slicedPath = wholePath.Split(':');
            if (slicedPath.Length != 2)
            {
                return;
            }
            ModId = slicedPath[0];
            Path = slicedPath[1];
        }

        public override string ToString() { return WholePath; }

        [GeneratedRegex(@"^[a-z_]+$", RegexOptions.IgnoreCase)]
        private static partial Regex ModIdRegex();

        [GeneratedRegex(@"^[a-z_]+(?:/[a-z0-9_]+)*$", RegexOptions.IgnoreCase)]
        private static partial Regex PathRegex();

        public static PathId Instance => new PathId();
    }
}