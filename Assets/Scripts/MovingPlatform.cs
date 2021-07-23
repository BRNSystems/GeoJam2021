using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float width;
    public float height;
    [Range(0.1f, 80 )] [SerializeField] private float speed = 1;

    private bool movingLeft = false;
    private bool movingUp = false;

    Vector3 vector;
    Vector3 object_position;
    Vector3 furthest_position;

    // Start is called before the first frame update
    void Start()
    {
        vector = transform.position;
        object_position = transform.position;
        furthest_position = object_position;
        furthest_position[0] += width;
        furthest_position[1] += height;
    }

    // Update is called once per frame
    void Update()
    {
        if (width > 0) {
            if (movingLeft) {
                if (vector[0] > object_position[0]) {
                    vector[0] -= speed * Time.deltaTime;
                } else {
                    movingLeft = !movingLeft;
                    vector[0] += speed * Time.deltaTime;
                }
            } else {
                if (vector[0] < furthest_position[0]) {
                    vector[0] += speed * Time.deltaTime;
                } else {
                    movingLeft = !movingLeft;
                    vector[0] -= speed * Time.deltaTime;
                }
            }
        } else if (width < 0) {
            if (movingLeft) {
                if (vector[0] > furthest_position[0]) {
                    vector[0] -= speed * Time.deltaTime;
                } else {
                    movingLeft = !movingLeft;
                    vector[0] += speed * Time.deltaTime;
                }
            } else {
                if (vector[0] < object_position[0]) {
                    vector[0] += speed * Time.deltaTime;
                } else {
                    movingLeft = !movingLeft;
                    vector[0] -= speed * Time.deltaTime;
                }
            }
        }

        if (height > 0) {
            if  (movingUp) {
                if (vector[1] < furthest_position[1]) {
                    vector[1] += speed * Time.deltaTime;
                } else {
                    movingUp = !movingUp;
                    vector[1] -= speed * Time.deltaTime;
                }
            } else {
                if (vector[1] > object_position[1]) {
                    vector[1] -= speed * Time.deltaTime;
                } else {
                    movingUp = !movingUp;
                    vector[1] += speed * Time.deltaTime;
                }
            }
        } else if (height < 0) {
            if  (movingUp) {
                if (vector[1] < object_position[1]) {
                    vector[1] += speed * Time.deltaTime;
                } else {
                    movingUp = !movingUp;
                    vector[1] -= speed * Time.deltaTime;
                }
            } else {
                if (vector[1] > furthest_position[1]) {
                    vector[1] -= speed * Time.deltaTime;
                } else {
                    movingUp = !movingUp;
                    vector[1] += speed * Time.deltaTime;
                }
            }
        }
        
        transform.position = vector;
    }
}
