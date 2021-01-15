using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float camHeight;

    GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(player.transform.position.x, camHeight, -10);





    }
}
