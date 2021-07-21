using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioClip checkpoint;
    public SpawnStorage spawnstor;
    public AudioSource sfx;

    public Sprite Green;
    public CircleCollider2D circ;
    public SpriteRenderer sprite;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Player") {
            circ.enabled = false;
            sprite.sprite = Green;
            spawnstor.spawnpoint = transform.position;
            sfx.clip = checkpoint;
            sfx.Play();
        }
    }
}
