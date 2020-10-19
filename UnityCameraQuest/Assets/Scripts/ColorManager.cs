using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private string[] _objectsName;
    private Color[] _objectsColor;

    public string[] ObjectsName
    {
        get => _objectsName;
    }
    public Color[] ObjectsColor
    {
        get => _objectsColor;
    }
    void Reset()
    {
        var _gameObjects = FindObjectsOfType<MeshRenderer>();
        _objectsColor = new Color[_gameObjects.Length];
        _objectsName = new string[_gameObjects.Length];

        for (int i = 0; i < _gameObjects.Length; i++)
        {
            _objectsColor[i] = _gameObjects[i].sharedMaterial.color;
            _objectsName[i] = _gameObjects[i].name;
        }
    }
}
