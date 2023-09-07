using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject target;
    public float speed;
    private Vector3 ptx;

    // Start is called before the first frame update
    void Start()
    {
        ptx = target.transform.position;
        transform.LookAt(ptx);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(ptx, new Vector3(0.0f, -1.0f, 0.0f), 1 * Time.deltaTime * speed);
    }
}
