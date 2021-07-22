using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform player;
    [Range(0.1f, 2)] [SerializeField] float smoothing = 0.6f;
    // Start is called before the first frame update

    Vector3 player_pos;
    Vector3 camera_pos;
    Vector2 difference = new Vector2(0, 0);

    void Start()
    {
        camera_pos = transform.position;

        camera_pos[2] = -10;

        transform.position = camera_pos;
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = player.transform.position;
        camera_pos = transform.position;

        difference[0] = player_pos[0] - camera_pos[0];
        difference[1] = player_pos[1] - camera_pos[1];

        float smoothing_ = smoothing / Time.deltaTime;

        camera_pos[0] += difference[0] / smoothing_;
        camera_pos[1] += difference[1] / smoothing_;

        transform.position = camera_pos;
    }
}
