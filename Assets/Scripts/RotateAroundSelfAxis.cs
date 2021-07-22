using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSelfAxis : MonoBehaviour
{
    public bool right_rotation = true;
    [Range(0f, 600f)] [SerializeField] public float speed = 1;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(right_rotation) {
            transform.localRotation *= Quaternion.AngleAxis(speed * Time.deltaTime, new Vector3(0f, 0f, -1f));
        } else {
           transform.localRotation *= Quaternion.AngleAxis(speed * Time.deltaTime, new Vector3(0f, 0f, 1f));
        }
    }
}
