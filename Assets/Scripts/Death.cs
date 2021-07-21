using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{

    public SpawnStorage spawnstor;
    public AudioClip damage;

    public AudioSource sfx;

    void Start() {
    }
    private void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Player") {
            collisionInfo.collider.transform.position = spawnstor.spawnpoint;
            collisionInfo.collider.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            sfx.clip = damage;
            sfx.Play();
        }
    }
}
