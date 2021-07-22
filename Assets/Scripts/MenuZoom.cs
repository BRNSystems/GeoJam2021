using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuZoom : MonoBehaviour
{
    public Camera cam;
    public GameObject objects;
    bool firstrun = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (firstrun){
            firstrun = false;
            while(cam.fieldOfView > 3f){
                cam.fieldOfView -= 0.001f;
            }
            objects.SetActive(true);
            while(cam.fieldOfView < 5f){
                cam.fieldOfView += 0.001f;
            }
        }
    }
}
