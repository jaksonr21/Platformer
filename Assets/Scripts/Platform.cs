using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Vector3 targetPos;

    public float speed;

    Vector3 startPos;

    bool toTarget = true;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (toTarget == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed);
        }

        if (transform.position == targetPos)
        {
            toTarget = false;
        }

        if (transform.position == startPos)
        {
            toTarget = true;
        }






    }
}
