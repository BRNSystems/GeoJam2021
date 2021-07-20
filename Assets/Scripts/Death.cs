using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{

    void Start() {
        Debug.Log("hello");
    }
    private void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        Debug.Log(collisionInfo.collider.transform);
        collisionInfo.collider.transform.position = Vector3.zero;
    }
}
