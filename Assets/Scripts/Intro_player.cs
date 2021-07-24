using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_player : MonoBehaviour
{

    public Animator animator;
    public AudioSource sfx;
    public AudioSource EngineSfx;
    public ParticleSystem explosion;
    public ParticleSystem engine;
    public Rigidbody2D rb;

    public bool crashed;
    private void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Planet") {
            animator.SetBool("crashed", true);
            crashed = true;
            explosion.Play();
            sfx.Play();
            engine.Stop();
            EngineSfx.Stop();
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetVelocity = rb.velocity;
        if(!crashed){
		    targetVelocity[0] = 12f;
            targetVelocity[1] = 0f;
        }
        else{
            targetVelocity[0] = 0f;
            targetVelocity[1] = 0f;
            StartCoroutine(Example());

        }
		rb.velocity = targetVelocity;
    }
        IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Tutorial");
    }
}
