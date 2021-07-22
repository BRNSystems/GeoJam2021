using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSelfAxis : MonoBehaviour
{
    public bool right_rotation = true;
    public bool flipping = false;
    [Range(0, (float)Math.PI * 2)] [SerializeField] public float flip_angle = 0;
    [Range(0, 60)] [SerializeField] public float speed = 1;

    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.rotation;

        if(right_rotation) {
            rotation[2] -= speed * Time.deltaTime;
        } else {
            rotation[2] += speed * Time.deltaTime;
        }
        Debug.Log(speed * Time.deltaTime);

        transform.rotation = rotation;
    }
}
