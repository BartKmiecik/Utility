using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotator : MonoBehaviour
{
    float angle = 360.0f; // Degree per time unit
    public float time = 1.0f; // Time unit in sec
    public Vector3 axis = Vector3.forward; // Rotation axis, here it the yaw axis

    Transform obj;

    private void Start()
    {
        obj = GetComponent<Transform>();
    }

    private void Update()
    {
        obj.RotateAround(Vector3.zero, axis, angle * Time.deltaTime / time);
    }

    public void ChangeDir()
    {
        axis = -axis;
    }
}
