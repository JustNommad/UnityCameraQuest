using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ColorManager))]
public class ColorManagerInspector : Editor
{
    private ColorManager cm;
    private Color[] _colors;
    private string[] _names;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (cm != null)
        {
            for (int i = 0; i < _names.Length; i++)
                EditorGUILayout.ColorField($"Color {_names[i]}", _colors[i]);
        }

        if (GUILayout.Button("Update default color"))
        {
            UpdateDefaultColor();
        }
        if (GUILayout.Button("Default Color"))
        {
            SetDefaultColor();
        }
    }

    void UpdateDefaultColor()
    {
        cm = target as ColorManager;
        if (cm != null)
        {
            _colors = cm.ObjectsColor;
            _names = cm.ObjectsName;
            for(int i = 0; i < _names.Length; i++)
                Debug.Log($"{_names[i]}");
        }
    }

    void SetDefaultColor()
    {
        var objects = FindObjectsOfType<MeshRenderer>();
        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = 0; j < _names.Length; j++)
            {
                if (_names[j].Equals(objects[i].name))
                    objects[i].material.color = _colors[j];
            }
        }
    }
}
