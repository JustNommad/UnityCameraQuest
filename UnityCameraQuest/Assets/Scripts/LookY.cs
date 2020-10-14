using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 4.0f;
    private float tempY = 0.0f;
    void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        tempY += mouseY * _sensitivity;
        tempY = Mathf.Clamp(tempY, -60.0f, 60.0f);
        if (tempY < 60.0f && tempY > -60.0f)
            newRotation.x -= mouseY * _sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
