using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outro_Player : MonoBehaviour
{

    public AudioSource enginesfx;
    public ParticleSystem engine;
    public Rigidbody2D rb;

    public bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(starting());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVelocity = rb.velocity;
        if(running){
		    targetVelocity[0] = 0f;
            targetVelocity[1] = 12f;
        }
        else{
            targetVelocity[0] = 0f;
            targetVelocity[1] = 0f;
            

        }
		rb.velocity = targetVelocity;
    }
        IEnumerator starting()
    {
        yield return new WaitForSecondsRealtime(3f);
        engine.Play();
        enginesfx.Play();
        yield return new WaitForSecondsRealtime(1f);
        engine.Stop();
        enginesfx.Stop();
        yield return new WaitForSecondsRealtime(3f);
        engine.Play();
        enginesfx.Play();
        yield return new WaitForSecondsRealtime(2f);
        engine.Stop();
        enginesfx.Stop();
        yield return new WaitForSecondsRealtime(3f);
        engine.Play();
        running  = true;
        enginesfx.Play();
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("Finish");
    }
}
