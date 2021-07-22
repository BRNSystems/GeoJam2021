using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuZoom : MonoBehaviour
{
    public Camera cam;
    public GameObject objects;
    bool flag1 = true;
    bool flag2 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag1){
            if(cam.orthographicSize > 1f){
                cam.orthographicSize -= 0.1f;
            }
            else{
                flag1 = false;
                flag2 = true;
                objects.SetActive(true);
            }
        }
        if(flag2){
            if(cam.orthographicSize < 5f){
                cam.orthographicSize += 0.06f;
            }
            else{
                flag2 = false;
            }
        }
    }
}
