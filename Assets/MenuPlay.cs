using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public LayerMask contactFilter;
    public AudioSource sfx;
    public MenuMouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if(Physics2D.CircleCast(mouse.pos, 1f, Vector2.zero, 0f, contactFilter)){
                sfx.Play();
                SceneManager.LoadScene("Tutorial");
            }
        }
    }
}
