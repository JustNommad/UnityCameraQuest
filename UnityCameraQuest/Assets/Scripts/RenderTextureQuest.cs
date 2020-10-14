using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureQuest : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Shader _shader;
    private Renderer _renderer;
    private RenderTexture _rTexture;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _rTexture = new RenderTexture(1024, 1024, 16, RenderTextureFormat.ARGB32);
        _rTexture.Create();
        _camera.targetTexture = _rTexture;
        _renderer.material = new Material(_shader);
        _renderer.material.mainTexture = _rTexture;
    }
}
