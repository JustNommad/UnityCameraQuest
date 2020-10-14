using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;
    [SerializeField] private float _speed = 4.0f;
    [SerializeField] private float _defaultFOV = 60.0f;
    [SerializeField] private float _newFOV = 30.0f;
    [SerializeField] private string _horizontal = "Horizontal";
    [SerializeField] private string _vertical = "Vertical";

    private bool _zoom = false;

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
        var horizontal = Input.GetAxis(_horizontal);
        var vertical = Input.GetAxis(_vertical);
        
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
