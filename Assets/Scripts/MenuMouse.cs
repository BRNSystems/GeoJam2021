using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMouse : MonoBehaviour
{
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos.y -= 4.69f;
        pos.x -= 8.66f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer){
            pos.x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * 40f;
            pos.y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 40f;
        }
        else{
            pos.x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * 10f;
            pos.y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 10f;
        }
        pos.z = -8f; 
        if (pos.x > 8.62f){
            pos.x = 8.62f;
        }
        if (pos.x < -8.62f){
            pos.x = -8.62f;
        }
        if (pos.y > 4.81f){
            pos.y = 4.81f;
        }
        if (pos.y < -4.68f){
            pos.y = -4.68f;
        }
        transform.position = pos;
        
    }
    public void play(){
        SceneManager.LoadScene("Tutorial");
    }
}
