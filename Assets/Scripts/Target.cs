using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public AudioClip target;
    public AudioSource sfx;
    public CircleCollider2D circ;
    public string nextScene;
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
            sfx.clip = target;
            sfx.Play();
            SceneManager.LoadScene(nextScene);

        }
    }
}
