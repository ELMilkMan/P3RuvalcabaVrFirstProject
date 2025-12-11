using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotateObject : MonoBehaviour
{
    [Header("Rotation speed in degrees per second")]
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}

