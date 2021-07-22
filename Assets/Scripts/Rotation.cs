using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public GameObject rotation_center;
    public bool static_center = true;
    public bool right_rotation = true;
    public bool flipping = false;
    [Range(0.1f, 8)] public float speed = 1;
    [Range(0, (float)Math.PI * 2)] public float flip_angle = 0;

    private float angle;
    private float magnitude;
    private Vector3 rotation_center_position;
    private Vector3 object_position;
    private float[] centralized_position;
    private float flipped_angle = 0;

    // Start is called before the first frame update
    void Start()
    {   

        object_position = transform.position;
        rotation_center_position = rotation_center.transform.position;

        centralized_position = new float[] {object_position[0] - rotation_center_position[0], object_position[1] - rotation_center_position[1]};

        angle = (float)Math.Atan2(centralized_position[0], centralized_position[1]);
        magnitude = (float)Math.Sqrt(Math.Pow(centralized_position[0], 2) + Math.Pow(centralized_position[1], 2));
    }

    // Update is called once per frame
    void Update()
    {      
        if (!static_center) {
            rotation_center_position = rotation_center.transform.position;
        }

        if (right_rotation) {
            angle -= speed * Time.deltaTime;
        } else {
            angle += speed * Time.deltaTime;
        }

        if (flipping) {
            flipped_angle += speed * Time.deltaTime;
            if (flipped_angle > flip_angle) {
                right_rotation = !right_rotation;
                flipped_angle -= flip_angle;
            }
        }

        centralized_position = new float[] {(float)Math.Cos(angle) * magnitude, (float)Math.Sin(angle) * magnitude};

        object_position[0] = centralized_position[0] + rotation_center_position[0];
        object_position[1] = centralized_position[1] + rotation_center_position[1];

        transform.position = object_position;
    }
}
