using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public bool rotate = false;
    public float rotateSpeed;

    public bool move = false;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(0 * Time.deltaTime, 10 * Time.deltaTime, 0 * Time.deltaTime);
        }

        if (move)
        {
            float y = Mathf.PingPong(Time.time * moveSpeed, 1) - 6;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
