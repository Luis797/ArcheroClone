using System;
using System.IO;
using UnityEngine;

public static class FileManager
{

    ///<summary>
    ///Write json string to the file of a given name
    ///</summary>
    public static bool WriteToFile(string a_FileName, string a_FileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            File.WriteAllText(fullPath, a_FileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    ///<summary>
    ///Determine if the file of the given name exits
    ///</summary>

    public static bool FileExits(string a_FileName)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);
        return File.Exists(fullPath);
    }

    ///<summary>
    ///Load the json string to a given variable
    ///</summary>

    public static bool LoadFromFile(string a_FileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            result = "";
            return false;
        }
    }
}