using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    private float rotationspeed;

    void Start()
    {
        rotationspeed = Random.Range(500, 1000);
    }

    void Update()
    {
        float rotation = rotationspeed * Time.deltaTime;
        transform.Rotate(rotation, rotation, 0);
    }

    public void ChangeMaterial()
    {
        rotationspeed = Random.Range(500, 1000);
    }
}
