using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStorage : MonoBehaviour
{

    // Start is called before the first frame update
    public Vector3 spawnpoint;
    void Start()
    {
        spawnpoint = transform.position;   
    }

}
