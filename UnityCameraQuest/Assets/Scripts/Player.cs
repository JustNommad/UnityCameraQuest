﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;
    [SerializeField] private float _speed = 4.0f;
    [SerializeField] private float _defaultFOV = 60.0f;
    [SerializeField] private float _newFOV = 30.0f;

    private bool _zoom = false;
    void Start()
    {
        
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.K) && !_zoom)
            _zoom = true;
        else if (Input.GetKeyDown(KeyCode.K) && _zoom)
            _zoom = false;
        ZoomIn();
    }

    void CalculateMovement()
    {
        var horizontal = gameObject.CompareTag("Player1") 
            ? Input.GetAxis("HorizontalWASD")
            :Input.GetAxis("HorizontalArrow");
        var vertical = gameObject.CompareTag("Player1") 
            ? Input.GetAxis("VerticalWASD")
            :Input.GetAxis("VerticalArrow");
        
        var diractional = new Vector3(horizontal, 0,vertical);
        transform.Translate(diractional * _speed * Time.deltaTime);
    }

    void ZoomIn()
    {
        if (_zoom)
        {
            foreach (var c in _cameras)
                c.fieldOfView = Mathf.Lerp(c.fieldOfView, _newFOV, 10.0f * Time.deltaTime);
        }
        else
        {
            foreach (var c in _cameras)
                c.fieldOfView = Mathf.Lerp(c.fieldOfView, _defaultFOV, 10.0f * Time.deltaTime);
        }

    }
}
