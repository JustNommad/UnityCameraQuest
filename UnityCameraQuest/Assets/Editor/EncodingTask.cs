using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;


[Serializable]
public class Stats
{
    public float speed;
    public int health;
    public string fullName;
    public string base64Texture;
}
public class EncodingTask : Editor
{
    public static Stats tempPlayerData;
    private static string _path = "Assets/EncodingFiles/";
    
    [MenuItem("Tools/Encoding/CSP")]
    public static void CSP()
    {
        File.WriteAllText("Assets/csp.rsp", "-r:System.IO.Compression.FileSystem.dll");
    }

    [MenuItem("Tools/Encoding/Download ZIP")]
    public static void DownloadZIP()
    {
        string uri = "https://dminsky.com/settings.zip";
        string outPath = Path.Combine("Assets/EncodingFiles", "settings.zip");
        
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        uwr.downloadHandler = new DownloadHandlerFile(outPath);
        var asyncOp = uwr.SendWebRequest();
        asyncOp.completed += (ap) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
                Debug.Log(uwr.error);
            else
            {
                Debug.Log("Competed");
            }
        };
    }

    [MenuItem("Tools/Encoding/Extract ZIP")]
    public static void ExtractZIP()
    {
        try
        {
            FileExceptionsCheck(delegate(string path)
            {
                ZipFile.ExtractToDirectory(path + "settings.zip",
                    path);
            });
        }
        catch (IOException e)
        {
            File.Delete(_path + "settings.json");
        }
        finally
        {
            FileExceptionsCheck(delegate(string path)
            {
                ZipFile.ExtractToDirectory(path + "settings.zip",
                    path);
            });
        }
    }

    [MenuItem("Tools/Encoding/Deserialize JSON")]
    public static void DesirializeJSON()
    {
        FileExceptionsCheck(delegate (string path)
        {
            var file = File.ReadAllText(path + "settings.json");
            tempPlayerData = JsonUtility.FromJson<Stats>(file);
        });
    }

    [MenuItem("Tools/Encoding/Change Wall Texture")]
    public static void ChangeWallTexture()
    {
        FileExceptionsCheck(WallTexture);
    }

    private static void WallTexture(string path)
    {
        var image = Convert.FromBase64String(tempPlayerData.base64Texture);
        Texture2D normal = new Texture2D(2,2);
        if (image.Length != 0)
        {
            File.WriteAllBytes(path + "image.jpg", image);
            var data = File.ReadAllBytes(path + "image.jpg");
            if (data.Length != 0)
                normal.LoadImage(data);
            
            var wall = GameObject.Find("Wall")?.GetComponent<MeshRenderer>()?.sharedMaterial;
            wall?.EnableKeyword("_NORMALMAP");
            wall?.SetTexture("_BumpMap", normal);
        }
    }

    [MenuItem("Tools/Encoding/Change Player Speed")]
    public static void ChangePlayerSpeed()
    {
        var player = GameObject.Find("Player").GetComponent<Player>();
        if (tempPlayerData != null)
        {
            player.Speed = tempPlayerData.speed;
        }
        else
            Debug.Log("Stats: Error");
    }
    
    [MenuItem("Tools/Encoding/Check Player")]
    public static void CheckPlayer()
    {
        if(tempPlayerData != null)
            Debug.Log($"{tempPlayerData.fullName}");
        else
            Debug.Log("null");
    }

    private static void FileExceptionsCheck(Action<string> action)
    {
        try
        {
            if (_path.Length >= 25)
                throw new PathTooLongException("Please! Give a short FilePath! FilePath: " + _path);
            
            action?.Invoke(_path);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("Please! Check your directory path!" + e.Message);
        }
        catch (PathTooLongException e)
        {
            Debug.Log(e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("IOException : " + e.Message);
            throw;
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e.Message);
        }
    }
}
