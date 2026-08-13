using Godot;
using System;

[GlobalClass]
public partial class PathId : Resource
{
    [Export]
    public string ModId { get; set; }
    [Export]
    public string Path { get; set; }

    public string WholePath => ModId + ":" + Path;

    public void SetPathFromWholePath(string wholePath)
    {
        string[] slicedPath = wholePath.Split(':');
        if (slicedPath.Length > 2)
            throw new ArgumentException("Wrong string path for the PathId: " + wholePath);
        ModId = slicedPath[0];
        Path = slicedPath[1];
    }
}
