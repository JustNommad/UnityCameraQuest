using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeColor : EditorWindow
{
    [MenuItem("Tools/All Objects/Change Color")]
    public static void ChangeColorAllObjects()
    {
        var objects = FindObjectsOfType<MeshRenderer>();
        foreach (var o in objects)
        {
            o.sharedMaterial.color = Color.green;
        }
    }
}
