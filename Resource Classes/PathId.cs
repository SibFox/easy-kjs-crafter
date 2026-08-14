using Godot;
using System;
using System.Diagnostics;

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
                if (value.Contains(':') || value.Contains('/'))
                    return;
                _modId = value;
            }
        }
        [Export]
        public string Path { 
            get { return _path; }
            set
            {
                if (value.Contains(':'))
                    return;
                _path = value;
            }
        }

        [Export]
        public string WholePath
        {
            get { return _modId + ":" + _path; }
            set { SetPathFromWholePath(value); }
        }

        public void SetPathFromWholePath(string wholePath)
        {
            string[] slicedPath = wholePath.Split(':');
            if (slicedPath.Length != 2)
                throw new ArgumentException("Wrong string path for the PathId: " + wholePath);
            _modId = slicedPath[0];
            _path = slicedPath[1];
        }
    }
}