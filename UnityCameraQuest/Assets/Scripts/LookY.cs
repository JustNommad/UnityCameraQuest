using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY;
        Debug.Log(newRotation.x);
        transform.localEulerAngles = newRotation;
    }
}
