using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHeightChecker : MonoBehaviour
{
    Vector3 v;
    List<float> y_positions = new List<float>();
    List<float> jump_peaks = new List<float>();

    // Update is called once per frame
    void Update()
    {
        v = transform.position;



    }
}
