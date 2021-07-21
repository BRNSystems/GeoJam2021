using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playpos = player.transform.position;
        playpos.z = playpos.z - 10;
        playpos.y = playpos.y + 3;
        transform.position = playpos;
    }
}
