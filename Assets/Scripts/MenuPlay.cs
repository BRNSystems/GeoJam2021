using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public LayerMask contactFilter;
    public AudioSource sfx;
    public MenuMouse mouse;
    public SpriteRenderer sr;
    private bool hover = false;
    private bool previous_hover = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.CircleCast(mouse.pos, 1f, Vector2.zero, 0f, contactFilter)){
            if (Input.GetMouseButtonDown(0)){
                sfx.Play();
                SceneManager.LoadScene("Intro");
            }

            previous_hover = hover;
            hover = true;
        } else {
            previous_hover = hover;
            hover = false;
        } 

        if (hover != previous_hover) {
            if(hover) {
                sr.color = new Color(202f / 255f, 202f / 255f, 242f / 255f, 201f / 255f);
            } else {
                sr.color = new Color(149f / 255f, 189f / 255f, 253f / 255f, 201f / 255f);
            }
        }
    }
}
