using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{

    void Start() {
    }
    private void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        collisionInfo.collider.transform.position = Vector3.zero;
    }
}
