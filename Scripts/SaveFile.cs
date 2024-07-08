using System.IO;
using UnityEngine;

public class SaveFile
{
    public string Load(string key)
    {
        var path = GetPath(key);
        Debug.Log(path);
        return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
    }

    public void Save(string key, string value)
    {
        var path = GetPath(key);
        File.WriteAllText(path, value);
    }

    private string GetPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, $"{key}.json");
    }
}
