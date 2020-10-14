using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 1.0f;
    void Update()
    {
        var mauseX = Input.GetAxis("Mouse X");
        var newRotation = transform.localEulerAngles;
        newRotation.y += _sensitivity * mauseX;
        transform.localEulerAngles = newRotation;
    }
}
